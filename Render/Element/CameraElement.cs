using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GameBrowser.Render.Element
{
    public class CameraElement : IRenderElement
    {
        public CameraElement(RenderTree renderTree) : base(renderTree) { }

        public override void Render(FrameEventArgs e)
        {
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, -Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            base.Render(e);
        }

        public override void Resize()
        {
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, RenderTree.ClientWidth / (float)RenderTree.ClientHeight, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            base.Resize();
        }
    }
}
