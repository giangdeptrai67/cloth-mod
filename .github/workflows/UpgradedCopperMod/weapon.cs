using Engine;
using Engine.Graphics;

namespace Game {
  public class DiaroniumSpearBlock : SpearBlock {
        public Texture2D m_texture;

        public DiaroniumSpearBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
  namespace Game {
  public class DiaroniumMacheteBlock : MacheteBlock {
        public Texture2D m_texture;

        public DiaroniumMacheteBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
    namespace Game {
  public class UpgradedCopperMacheteBlock : MacheteBlock {
        public Texture2D m_texture;

        public UpgradedCopperMacheteBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
      namespace Game {
  public class UpgradedCopperSpearBlock : SpearBlock {
        public Texture2D m_texture;

        public UpgradedCopperSpearBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
        namespace Game {
  public class UpgradedIronMacheteBlock : MacheteBlock {
        public Texture2D m_texture;

        public UpgradedIronMacheteBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
      namespace Game {
  public class UpgradedIronSpearBlock : SpearBlock {
        public Texture2D m_texture;

        public UpgradedIronSpearBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
  }
}
