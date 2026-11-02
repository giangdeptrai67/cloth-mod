
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
            // Only one Father Bear at a time
            foreach (Entity entity in Project.Entities)
            {
                if (entity.ValuesDictionary.DatabaseObject.Name == "FatherBear")
                {
                    return false;
                }
            }

            if (componentMiner.ComponentPlayer != null)
            {
                componentMiner.ComponentPlayer.ComponentGui.DisplayLargeMessage(
                    "WARNING",
                    "An unknown entity has been summoned",
                    3f,
                    0f
                );
            }

            // Get player position
            Vector3 playerPosition =
                componentMiner.ComponentCreature.ComponentBody.Position;

            // Random direction and distance (10 to 30 blocks)
            Game.Random random = new Game.Random();
            float angle = random.Float(0f, MathUtils.PI * 2f);
            float distance = random.Float(10f, 30f);

            // Turn that into a spot on the map
            int x = Terrain.ToCell(playerPosition.X + MathUtils.Cos(angle) * distance);
            int z = Terrain.ToCell(playerPosition.Z + MathUtils.Sin(angle) * distance);

            // Find the ground height at that spot
            Terrain terrain = Project.FindSubsystem<SubsystemTerrain>(true).Terrain;
            int y = terrain.CalculateTopmostCellHeight(x, z) + 1;

            // Create Father Bear entity
            Entity bear = DatabaseManager.CreateEntity(
                Project,
                "FatherBear",
                true
            );

            // Set bear position (middle of the block)
            bear.FindComponent<ComponentBody>(true).Position =
                new Vector3(x + 0.5f, y, z + 0.5f);

            // Add bear to world
            Project.AddEntity(bear);

            // Play the bear roar where the bear appeared
            SubsystemAudio audio = Project.FindSubsystem<SubsystemAudio>(true);
            audio.PlaySound(
                "Audio/Creatures/BearAngry",
                1f,
                -0.4f,
                bear.FindComponent<ComponentBody>(true).Position,
                40f,
                true
            );

            return true;
        }
    }
}
