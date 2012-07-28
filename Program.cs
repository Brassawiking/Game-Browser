using System;
using System.Xml;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

using Jint;

namespace GameBrowser
{
    class GameBrowser : GameWindow
    {
        public XmlDocument m_dom;
        public JintEngine m_js;

        public GameBrowser()
            : base(800, 600, GraphicsMode.Default, "Game Browser")
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            m_js = new JintEngine();
            m_js.SetParameter("x", 0.0f);
            m_js.SetFunction("moveX", new Action<double>(x => {
                var triangle = m_dom.GetElementsByTagName("triangle")[0];
                foreach (XmlAttribute attr in triangle.Attributes)
                {
                    if (attr.Name == "x")
                    {
                        attr.Value = x.ToString();
                    }
                }
            
            }));

            
            m_js.SetFunction("moveX", new Action<double>(moveX));

            var reader = new XmlTextReader("../../game.xml");
            m_dom = new XmlDocument();
            m_dom.Load(reader);
            reader.Close();
        }

        protected void moveX(double x)
        {
            var triangle = m_dom.GetElementsByTagName("triangle")[0];
            foreach (XmlAttribute attr in triangle.Attributes)
            {
                if (attr.Name == "x")
                {
                    attr.Value = x.ToString();
                }
            }
        }
               
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
            {
                Exit();
            }

            m_js.Run("x = x+0.005; moveX(x);");                
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            var viewport = m_dom.GetElementsByTagName("viewport").Item(0);
            var nodes = viewport.ChildNodes;


            foreach(XmlNode node in nodes) 
            {
                if (node.Name == "triangle")
                {
                    var x = 0.0;
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        if (attr.Name == "x")
                        {
                            x = float.Parse(attr.Value);
                        }
                    }
                    GL.Begin(BeginMode.Triangles);

                    GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(x-1.0f, -1.0f, 4.0f);
                    GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(x+1.0f, -1.0f, 4.0f);
                    GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(x+0.0f, 1.0f, 4.0f);

                    GL.End();
                }
            }

            SwapBuffers();
        }

        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (GameBrowser game = new GameBrowser())
            {
                game.Run(30.0);
            }
        }
    }
}