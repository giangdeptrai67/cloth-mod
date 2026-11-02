using GameEntitySystem;

namespace Game
{
    public class ComponentNoRunAway : ComponentBehavior, IUpdateable
    {
        // 0 = "never choose me", so this behavior never takes control
        public override float ImportanceLevel
        {
            get { return 0f; }
        }

        public int UpdateOrder
        {
            get { return 0; }
        }

        public void Update(float dt)
        {
            // does nothing on purpose
        }
    }
}
