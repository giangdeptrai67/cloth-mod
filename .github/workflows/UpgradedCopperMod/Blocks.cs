using Engine;
using Engine.Graphics;

namespace Game {
public class BlockOfUpgradedCopperBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfUpgradedCopperBlock() : base(1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
public class BlockOfUpgradedIronBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfUpgradedIronBlock() : base(3) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
public class BlockOfDiaroniumBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfDiaroniumBlock() : base(2) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
}
