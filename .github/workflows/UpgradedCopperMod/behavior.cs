using Engine;
using GameEntitySystem;
// học code từ claude thật sự rất dễ
namespace Game
{
    public class SubsystemBearCallWhistleBehavior : SubsystemBlockBehavior
    {
        public override int[] HandledBlocks
        {
            get { return new int[] { BlocksManager.GetBlockIndex(typeof(BearCallWhistleBlock), true) }; }
        }

        public override bool OnUse(Ray3 ray, ComponentMiner componentMiner)
        {
            if (componentMiner.ComponentPlayer != null)
                componentMiner.ComponentPlayer.ComponentGui.DisplayLargeMessage("TEST", "it works", 3f, 0f);
            return true;
        }
    }
    public override bool OnUse(Ray3 ray, ComponentMiner componentMiner)
{
    // 1. Where is the player? Save it in a box named playerPosition.
    Vector3 playerPosition = componentMiner.ComponentCreature.ComponentBody.Position;

    // 2. Make a new Father Bear (like the egg does). Save it in a box named bear.
    Entity bear = DatabaseManager.CreateEntity(Project, "FatherBear", true);

    // 3. Decide where it stands: 3 blocks to the side of the player.
    bear.FindComponent<ComponentBody>(true).Position = playerPosition + new Vector3(3f, 0f, 0f);

    // 4. Put it into the world, so it really appears.
    Project.AddEntity(bear);

    return true;
    }
}
