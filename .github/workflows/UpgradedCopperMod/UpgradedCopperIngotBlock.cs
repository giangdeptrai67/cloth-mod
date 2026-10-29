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
}
