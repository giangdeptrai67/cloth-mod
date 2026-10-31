namespace Game {
    public class UpgradedCopperModLoader : ModLoader {
        public override void __ModInitialize() { }
    }
}
    using System;
using Engine;
using GameEntitySystem;

namespace Game
{
    public class BearHeadModLoader : ModLoader
    {
        private static readonly Random m_random = new Random();

        public override void __ModInitialize()
        {
            ModsManager.RegisterHook("OnEntityRemove", this);
        }

        public override void OnEntityRemove(Entity entity)
        {
            // only bears (Bear_Brown, Bear_Black, Bear_Polar)
            string name = entity.ValuesDictionary.DatabaseObject.Name;
            if (!name.StartsWith("Bear_"))
                return;

            // only real deaths, not despawns
            ComponentHealth health = entity.FindComponent<ComponentHealth>();
            if (health == null || health.Health > 0f)
                return;

            // 20% chance
            if (m_random.Float(0f, 1f) >= 0.2f)
                return;

            ComponentBody body = entity.FindComponent<ComponentBody>();
            if (body == null)
                return;

            SubsystemPickables pickables = entity.Project.FindSubsystem<SubsystemPickables>(true);
            int value = Terrain.MakeBlockValue(BlocksManager.GetBlockIndex(typeof(BearHeadBlock), true));
            pickables.AddPickable(value, 1, body.Position + new Vector3(0f, 0.5f, 0f), Vector3.Zero, null);
        }
    }
}

