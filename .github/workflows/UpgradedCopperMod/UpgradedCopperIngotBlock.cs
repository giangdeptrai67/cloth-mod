
using System.Collections.Generic;
using Engine;
using Engine.Graphics;

namespace Game {
    public class UpgradedCopperIngotBlock : IngotBlock {
        public Texture2D m_texture;

        public UpgradedCopperIngotBlock() : base("CopperIngot") { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/copperingotplus");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class UpgradedIronIngotBlock : IngotBlock {
        public Texture2D m_texture;

        public UpgradedIronIngotBlock() : base("CopperIngot") { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/ironingotplus");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class HalfUpgradedIronIngotBlock : IngotBlock {
        public Texture2D m_texture;

        public HalfUpgradedIronIngotBlock() : base("CopperIngot") { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/ironingotplushalf");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
        public class ChunkOfIronAndDiamondBlock : ChunkBlock {
        public Texture2D m_texture;

        public ChunkOfIronAndDiamondBlock() : base(
    Matrix.CreateRotationX(1f) * Matrix.CreateRotationZ(2f),
    Matrix.CreateScale(16f, 16f, 1f) * Matrix.CreateTranslation(0f, -15f, 0f),
    Color.White,
    false
) { }
        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/chunkofironanddiamond");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
    public class DiaroniumIngotBlock : IngotBlock {
        public Texture2D m_texture;

        public DiaroniumIngotBlock() : base("CopperIngot") { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumingot");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class HalfUpgradedDiaroniumIngotBlock : IngotBlock {
        public Texture2D m_texture;

        public HalfUpgradedDiaroniumIngotBlock() : base("CopperIngot") { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/halfupgradeddiaroniumingot");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class BearHeadBlock : Block
{
    private BlockMesh m_standaloneBlockMesh = new BlockMesh();
    private BlockMesh[] m_blockMeshesByRotation = new BlockMesh[4];
    private Texture2D m_texture;

    
    private const int RotationOffset = 0;

    public override void Initialize()
    {
        Model model = ContentManager.Get<Model>("Models/BearHead");
        ModelMesh mesh = model.FindMesh("BearHead");
        Matrix boneTransform = BlockMesh.GetBoneAbsoluteTransform(mesh.ParentBone);

        m_standaloneBlockMesh.AppendModelMeshPart(
            mesh.MeshParts[0], boneTransform, false, false, false, false, Color.White);

        for (int i = 0; i < 4; i++)
        {
            m_blockMeshesByRotation[i] = new BlockMesh();
            m_blockMeshesByRotation[i].AppendModelMeshPart(
                mesh.MeshParts[0],
                boneTransform * Matrix.CreateRotationY(i * MathUtils.PI / 2f) * Matrix.CreateTranslation(0.5f, 0.5f, 0.5f),
                false, false, false, false, Color.White);
        }

        m_texture = ContentManager.Get<Texture2D>("Textures/Creature/bearheadtexture.png");
        base.Initialize();
    }

    public override BlockPlacementData GetPlacementValue(SubsystemTerrain subsystemTerrain,
    ComponentMiner componentMiner, int value, TerrainRaycastResult raycastResult)
{
    Vector3 forward = Matrix.CreateFromQuaternion(
        componentMiner.ComponentCreature.ComponentCreatureModel.EyeRotation).Forward;
    int rotation = ((int)System.Math.Round(MathUtils.Atan2(forward.X, forward.Z) / (MathUtils.PI / 2f)) + RotationOffset) & 3;

    BlockPlacementData result = new BlockPlacementData();
    result.Value = Terrain.ReplaceData(Terrain.ReplaceContents(0, BlockIndex), rotation);
    result.CellFace = raycastResult.CellFace;
    return result;
}
    {
        Vector3 forward = Matrix.CreateFromQuaternion(
            componentMiner.ComponentCreature.ComponentCreatureModel.EyeRotation).Forward;
        int rotation = ((int)MathUtils.Round(MathUtils.Atan2(forward.X, forward.Z) / (MathUtils.PI / 2f)) + RotationOffset) & 3;
        BlockPlacementData result;
        result.Value = Terrain.ReplaceData(Terrain.ReplaceContents(0, BlockIndex), rotation);
        result.CellFace = raycastResult.CellFace;
        BlockPlacementData result = new BlockPlacementData();
    }

    public override void GenerateTerrainVertices(BlockGeometryGenerator generator,
        TerrainGeometry geometry, int value, int x, int y, int z)
    {
        int rotation = Terrain.ExtractData(value) & 3;
        generator.GenerateMeshVertices(this, x, y, z, m_blockMeshesByRotation[rotation], Color.White, null,
            geometry.GetGeometry(m_texture).SubsetOpaque);
    }
        public override void GetDropValues(SubsystemTerrain subsystemTerrain, int oldValue, int newValue,
        int toolLevel, List<BlockDropValue> dropValues, out bool showDebris)
    {
        dropValues.Add(new BlockDropValue { Value = Terrain.MakeBlockValue(BlockIndex), Count = 1 });
        showDebris = true;
    }

    public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value, Color color,
        float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
    {
        BlocksManager.DrawMeshBlock(primitivesRenderer, m_standaloneBlockMesh, m_texture,
            color, size, ref matrix, environmentData);
    }
}
}


