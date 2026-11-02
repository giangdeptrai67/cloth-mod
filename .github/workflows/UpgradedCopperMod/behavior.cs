using Engine;
using GameEntitySystem;

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
}
