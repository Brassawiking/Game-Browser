using System;
using System.Xml;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

using Jint;

using GameBrowser.Render;

namespace GameBrowser.System
{
    class GameBrowser : GameWindow
    {
        public XmlDocument m_dom;
        public JintEngine m_js;
        public RenderTree m_renderTree; 

        public GameBrowser()
            : base(800, 600, GraphicsMode.Default, "Game Browser")
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            m_js = new JintEngine();
            m_js.SetParameter("x", 0.0f);
            m_js.SetFunction("moveX", new Action<double>(x =>
            {
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

            m_renderTree = new RenderTreeBuilder().Build();
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
            m_renderTree.Resize(Width, Height); 
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
            m_renderTree.Render(e);
            SwapBuffers();
        }
    }
}
