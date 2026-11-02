
using Engine;
using GameEntitySystem;

namespace Game
{
    public class SubsystemBearCallWhistleBehavior : SubsystemBlockBehavior
    {
        public override int[] HandledBlocks
        {
            get
            {
                return new int[]
                {
                    BlocksManager.GetBlockIndex(typeof(BearCallWhistleBlock), true)
                };
            }
        }

        public override bool OnUse(Ray3 ray, ComponentMiner componentMiner)
        {
            if (componentMiner.ComponentPlayer != null)
            {
                componentMiner.ComponentPlayer.ComponentGui.DisplayLargeMessage(
                    "WARNING",
                    "An unknown entity has been called",
                    3f,
                    0f
                );
            }

            // Get player position
            Vector3 playerPosition =
                componentMiner.ComponentCreature.ComponentBody.Position;

            // Create Father Bear entity
            Entity bear = DatabaseManager.CreateEntity(
                Project,
                "FatherBear",
                true
            );

            // Set bear position
            bear.FindComponent<ComponentBody>(true).Position =
                playerPosition + new Vector3(3f, 0f, 0f);

            // Add bear to world
            Project.AddEntity(bear);

            return true;
        }
    }
}
