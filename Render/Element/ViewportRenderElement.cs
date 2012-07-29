using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GameBrowser.Render.Element
{
    public class ViewportRenderElement : IRenderElement
    {
        public ViewportRenderElement(RenderTree renderTree) : base(renderTree) { }

        public override void Render(FrameEventArgs e)
        {
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            base.Render(e);
        }

        public override void Resize()
        {
            GL.Viewport(0, 0, RenderTree.ClientWidth, RenderTree.ClientHeight);

            base.Resize();
        }
    }
}
