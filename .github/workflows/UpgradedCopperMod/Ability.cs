using Engine;
using GameEntitySystem;
using TemplatesDatabase;

namespace Game
{
    public class ComponentBossDigger : Component, IUpdateable
    {
        private ComponentBody m_body;
        private SubsystemTerrain m_subsystemTerrain;
        private SubsystemPlayers m_subsystemPlayers;
        private float m_timer;

        public int UpdateOrder
        {
            get { return 0; }
        }

        // Load runs once, when the bear is created: find what we need
        public override void Load(ValuesDictionary valuesDictionary, IdToEntityMap idToEntityMap)
        {
            base.Load(valuesDictionary, idToEntityMap);
            m_body = Entity.FindComponent<ComponentBody>(true);
            m_subsystemTerrain = Project.FindSubsystem<SubsystemTerrain>(true);
            m_subsystemPlayers = Project.FindSubsystem<SubsystemPlayers>(true);
        }

        // Update runs all the time (every frame)
        public void Update(float dt)
        {
            // only act twice per second, not every frame
            m_timer += dt;
            if (m_timer < 0.5f) return;
            m_timer = 0f;

            // 1. find the nearest player, and stop if there is none or too far
            ComponentPlayer player = m_subsystemPlayers.FindNearestPlayer(m_body.Position);
            if (player == null) return;
            Vector3 toPlayer = player.ComponentBody.Position - m_body.Position;
            if (toPlayer.Length() > 25f) return;

            // 2. a spot 2 blocks from the bear, in the direction of the player
            Vector3 center = m_body.Position + Vector3.Normalize(toPlayer) * 2f + new Vector3(0f, 1f, 0f);
            int cx = Terrain.ToCell(center.X);
            int cy = Terrain.ToCell(center.Y);
            int cz = Terrain.ToCell(center.Z);

            // 3. break every block in a 3x3x3 cube around that spot
            for (int x = cx - 1; x <= cx + 1; x++)
            {
                for (int y = cy - 1; y <= cy + 1; y++)
                {
                    for (int z = cz - 1; z <= cz + 1; z++)
                    {
                        if (y < 1 || y > 126) continue;
                        if (m_subsystemTerrain.Terrain.GetCellContentsFast(x, y, z) != 0)
                        {
                            m_subsystemTerrain.DestroyCell(0, x, y, z, 0, true, false);
                        }
                    }
                }
            }
        }
    }
public class ComponentBearSummon : Component, IUpdateable
{
    SubsystemCreatureSpawn m_spawn;
    ComponentCreature m_creature;
    ComponentChaseBehavior m_chase;
    float m_timer;
    public int UpdateOrder => 0;

    public override void Load(ValuesDictionary vd, IdToEntityMap map)
    {
        base.Load(vd, map);
        m_spawn = Project.FindSubsystem<SubsystemCreatureSpawn>(true);
        m_creature = Entity.FindComponent<ComponentCreature>(true);
        m_chase = Entity.FindComponent<ComponentChaseBehavior>(true);
    }

    public void Update(float dt)
    {
        m_timer += dt;
        if (m_chase.Target != null && m_timer > 20f)
        {
            m_timer = 0f;
            Vector3 pos = m_creature.ComponentBody.Position;
m_spawn.SpawnCreature("BearCub", pos + new Vector3(2f, 0f, 0f), false);
m_spawn.SpawnCreature("BearCub", pos + new Vector3(-2f, 0f, 0f), false);
Vector3 pos = m_creature.ComponentBody.Position;
for (int i = 0; i < 2; i++)
{
    float x = (i == 0) ? 2f : -2f;
    Entity cub = m_spawn.SpawnCreature("BearCub", pos + new Vector3(x, 0f, 0f), false);
    if (cub != null)
    {
        ComponentChaseBehavior cubChase = cub.FindComponent<ComponentChaseBehavior>();
        if (cubChase != null)
        {
            cubChase.Attack(m_chase.Target, 30f, 60f, true);
        }
    }
}
        }
    }
    
}
}
