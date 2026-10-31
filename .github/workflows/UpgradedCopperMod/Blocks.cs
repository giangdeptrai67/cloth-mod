using Engine;
using Engine.Graphics;

namespace Game {
public class BlockOfUpgradedCopperBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfUpgradedCopperBlock() { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
public class BlockOfUpgradedIronBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfUpgradedIronBlock() { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
public class BlockOfDiaroniumBlock : CubeBlock {
        public Texture2D m_texture;

        public BlockOfDiaroniumBlock() { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/Block/modedoretexture");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
}
}
