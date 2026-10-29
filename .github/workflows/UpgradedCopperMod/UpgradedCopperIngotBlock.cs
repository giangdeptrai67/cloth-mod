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
    }
