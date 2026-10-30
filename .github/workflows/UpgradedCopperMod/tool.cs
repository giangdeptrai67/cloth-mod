using Engine;
using Engine.Graphics;

namespace Game {
public class DiaroniumPickaxeBlock : PickaxeBlock {
        public Texture2D m_texture;

        public DiaroniumPickaxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
 }
    public class DiaroniumAxeBlock : AxeBlock {
        public Texture2D m_texture;

        public DiaroniumAxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class DiaroniumShovelBlock : ShovelBlock {
        public Texture2D m_texture;

        public DiaroniumShovelBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class UpgradedCopperPickaxeBlock : PickaxeBlock {
        public Texture2D m_texture;

        public UpgradedCopperPickaxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
 }
    public class UpgradedCopperAxeBlock : AxeBlock {
        public Texture2D m_texture;

        public UpgradedCopperAxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class UpgradedCopperShovelBlock : ShovelBlock {
        public Texture2D m_texture;

        public UpgradedCopperShovelBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class UpgradedIronPickaxeBlock : PickaxeBlock {
        public Texture2D m_texture;

        public UpgradedIronPickaxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
 }
    public class UpgradedIronAxeBlock : AxeBlock {
        public Texture2D m_texture;

        public UpgradedIronAxeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
    public class UpgradedIronShovelBlock : ShovelBlock {
        public Texture2D m_texture;

        public UpgradedIronShovelBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
    }
        public class UpgradedIronRakeBlock : RakeBlock {
        public Texture2D m_texture;

        public UpgradedIronRakeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
       
public class UpgradedCopperRakeBlock : RakeBlock {
        public Texture2D m_texture;

        public UpgradedCopperRakeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/coppertexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
   public class DiaroniumRakeBlock : RakeBlock {
        public Texture2D m_texture;

        public DiaroniumRakeBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
        public class UpgradedIronHammerBlock : HammerBlock {
        public Texture2D m_texture;

        public UpgradedIronHammerBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/irontexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
        public class UpgradedDiaroniumHammerBlock : HammerBlock {
        public Texture2D m_texture;

        public UpgradedDiaroniumHammerBlock() : base(0, 1) { }

        public override void Initialize() {
            base.Initialize();
            m_texture = ContentManager.Get<Texture2D>("Textures/diaroniumtexturetw");
        }

        public override Texture2D GetDefaultTexture(int value) => m_texture;
        }
}
