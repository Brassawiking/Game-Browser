using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GameBrowser.Render.Element
{
    public class BoxElement : IRenderElement
    {
        public BoxElement(RenderTree renderTree) : base(renderTree) { }

        public override void Render(FrameEventArgs e)
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, -4.0f);
            GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, -4.0f);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(1.0f, 1.0f, -4.0f);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(-1.0f, 1.0f, -4.0f);

            GL.End();
            base.Render(e);
        }

        public override void Resize()
        {
            base.Resize();
        }
    }
}
