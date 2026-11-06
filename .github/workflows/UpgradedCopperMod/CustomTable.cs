using System;
using System.Xml.Linq;
using Engine;
using GameEntitySystem;
using TemplatesDatabase;

namespace Game
{
    public class SubsystemSoulTableBlockBehavior : SubsystemInventoryBlockBehavior<ComponentSoulTable>
    {
        public override int[] HandledBlocks
        {
            get { return new int[] { SoulTableBlock.Index }; }
        }

        public SubsystemSoulTableBlockBehavior() : base("SoulTable")
        {
        }

        public override bool OnInteract(TerrainRaycastResult raycastResult, ComponentMiner componentMiner)
        {
            if (componentMiner.ComponentPlayer == null)
            {
                return false;
            }
            ComponentBlockEntity blockEntity = m_subsystemBlockEntities.GetBlockEntity(
                raycastResult.CellFace.X, raycastResult.CellFace.Y, raycastResult.CellFace.Z);
            if (blockEntity == null)
            {
                return false;
            }
            ComponentSoulTable component = blockEntity.Entity.FindComponent<ComponentSoulTable>(true);
            componentMiner.ComponentPlayer.ComponentGui.ModalPanelWidget =
                new SoulTableWidget(componentMiner.Inventory, component);
            AudioManager.PlaySound("Audio/UI/ButtonClick", 1f, 0f, 0f);
            return true;
        }
    }

    public class SoulTableWidget : CanvasWidget
    {
        private readonly ComponentSoulTable m_component;

        public SoulTableWidget(IInventory inventory, ComponentSoulTable component)
        {
            m_component = component;
            WidgetsManager.LoadWidgetContents(this, this, ContentManager.Get<XElement>("Widgets/SoulTableWidget"));

            GridPanelWidget inventoryGrid = Children.Find<GridPanelWidget>("InventoryGrid");
            GridPanelWidget craftingGrid = Children.Find<GridPanelWidget>("CraftingGrid");
            InventorySlotWidget resultSlot = Children.Find<InventorySlotWidget>("CraftingResultSlot");
            InventorySlotWidget remainsSlot = Children.Find<InventorySlotWidget>("CraftingRemainsSlot");

            int slot = 10;
            for (int y = 0; y < inventoryGrid.RowsCount; y++)
            {
                for (int x = 0; x < inventoryGrid.ColumnsCount; x++)
                {
                    InventorySlotWidget widget = new InventorySlotWidget();
                    widget.AssignInventorySlot(inventory, slot++);
                    inventoryGrid.Children.Add(widget);
                    inventoryGrid.SetWidgetCell(widget, new Point2(x, y));
                }
            }

            slot = 0;
            for (int y = 0; y < craftingGrid.RowsCount; y++)
            {
                for (int x = 0; x < craftingGrid.ColumnsCount; x++)
                {
                    InventorySlotWidget widget = new InventorySlotWidget();
                    widget.AssignInventorySlot(component, slot++);
                    craftingGrid.Children.Add(widget);
                    craftingGrid.SetWidgetCell(widget, new Point2(x, y));
                }
            }

            resultSlot.AssignInventorySlot(component, component.ResultSlotIndex);
            remainsSlot.AssignInventorySlot(component, component.RemainsSlotIndex);
        }

        public override void Update()
        {
            if (!m_component.IsAddedToProject)
            {
                ParentWidget.Children.Remove(this);
            }
        }
    }

    public class ComponentSoulTable : ComponentInventoryBase
    {
        private const int GridSize = 3;
        private const int RecipeGridWidth = 6;
        private const float RequiredPlayerLevel = 5f;

        private SubsystemTerrain m_subsystemTerrain;
        private CraftingRecipe m_matchedRecipe;
        private readonly string[] m_matchedIngredients = new string[RecipeGridWidth * RecipeGridWidth];

        public int ResultSlotIndex
        {
            get { return SlotsCount - 2; }
        }

        public int RemainsSlotIndex
        {
            get { return SlotsCount - 1; }
        }

        public override void Load(ValuesDictionary valuesDictionary, IdToEntityMap idToEntityMap)
        {
            base.Load(valuesDictionary, idToEntityMap);
            m_subsystemTerrain = Project.FindSubsystem<SubsystemTerrain>(true);
            UpdateCraftingResult();
        }

        public override int GetSlotCapacity(int slotIndex, int value)
        {
            if (slotIndex >= SlotsCount - 2)
            {
                return 0;
            }
            return base.GetSlotCapacity(slotIndex, value);
        }

        public override void AddSlotItems(int slotIndex, int value, int count)
        {
            base.AddSlotItems(slotIndex, value, count);
            UpdateCraftingResult();
        }

        public override int RemoveSlotItems(int slotIndex, int count)
        {
            if (slotIndex == ResultSlotIndex && m_matchedRecipe != null)
            {
                bool canTake = true;
                if (m_matchedRecipe.RemainsValue != 0 && m_matchedRecipe.RemainsCount > 0)
                {
                    Slot remains = m_slots[RemainsSlotIndex];
                    if (remains.Count == 0 || remains.Value == m_matchedRecipe.RemainsValue)
                    {
                        remains.Value = m_matchedRecipe.RemainsValue;
                        remains.Count += m_matchedRecipe.RemainsCount;
                    }
                    else
                    {
                        canTake = false;
                    }
                }
                if (!canTake)
                {
                    return 0;
                }
                for (int i = 0; i < GridSize * GridSize; i++)
                {
                    if (m_slots[i].Count > 0)
                    {
                        m_slots[i].Count--;
                    }
                }
            }
            int removed = base.RemoveSlotItems(slotIndex, count);
            UpdateCraftingResult();
            return removed;
        }

        private void UpdateCraftingResult()
        {
            for (int i = 0; i < m_matchedIngredients.Length; i++)
            {
                m_matchedIngredients[i] = null;
            }
            for (int y = 0; y < GridSize; y++)
            {
                for (int x = 0; x < GridSize; x++)
                {
                    int slotIndex = x + y * GridSize;
                    int value = GetSlotValue(slotIndex);
                    if (value != 0 && GetSlotCount(slotIndex) > 0)
                    {
                        m_matchedIngredients[x + y * RecipeGridWidth] = CraftingRecipesManager.EncodeIngredient(
                            Terrain.ExtractContents(value), Terrain.ExtractData(value));
                    }
                }
            }
            m_matchedRecipe = CraftingRecipesManager.FindMatchingRecipe(
                m_subsystemTerrain, m_matchedIngredients, 0f, RequiredPlayerLevel);
            if (m_matchedRecipe != null && m_matchedRecipe.ResultValue != 0)
            {
                m_slots[ResultSlotIndex].Value = m_matchedRecipe.ResultValue;
                m_slots[ResultSlotIndex].Count = m_matchedRecipe.ResultCount;
            }
            else
            {
                m_matchedRecipe = null;
                m_slots[ResultSlotIndex].Value = 0;
                m_slots[ResultSlotIndex].Count = 0;
            }
        }
    }
}
