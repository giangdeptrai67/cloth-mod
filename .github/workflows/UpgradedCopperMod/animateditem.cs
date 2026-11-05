using Engine;
using Engine.Graphics;

namespace Game
{
    public class SoulOfTheForestBlock : FlatBlock
    {

        private Texture2D[] m_frames;
        private const int FrameCount = 4;
        private const double Fps = 8.0;

        public override void Initialize()
        {
            base.Initialize();
            m_frames = new Texture2D[FrameCount];
            for (int i = 0; i < FrameCount; i++)
            {
                // files: Textures/soulforest1 ... soulforest4
                m_frames[i] = ContentManager.Get<Texture2D>("Textures/Animated/soulforest" + (i + 1));
            }
        }

        public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value,
            Color color, float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
        {
            // pick the frame from the time
            int frame = (int)(Time.RealTime * Fps) % FrameCount;

            BlocksManager.DrawFlatBlock(primitivesRenderer, value, size, ref matrix,
                m_frames[frame], color, false, environmentData);
        }
    }
}
