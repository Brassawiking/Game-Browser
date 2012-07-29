using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GameBrowser.Render.Element
{
    public class BoxRenderElement : IRenderElement
    {
        public BoxRenderElement(RenderTree renderTree) : base(renderTree) { }

        public double Color { get; set; }

        public override void Render(FrameEventArgs e)
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color, 1.0-Color, 0); 
            GL.Vertex3(-1.0f, -1.0f, -4.0f);
            GL.Vertex3( 1.0f, -1.0f, -4.0f);
            GL.Vertex3( 1.0f,  1.0f, -4.0f);
            GL.Vertex3(-1.0f,  1.0f, -4.0f);

            GL.End();
            base.Render(e);
        }

        public override void Resize()
        {
            base.Resize();
        }
    }
}
