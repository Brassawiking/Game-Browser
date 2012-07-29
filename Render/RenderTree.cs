using GameBrowser.Render.Element;
using OpenTK;

namespace GameBrowser.Render
{
    public class RenderTree
    {
        public IRenderElement RootElement { get; set; }
        public int ClientWidth { get; set; }
        public int ClientHeight { get; set; }

        public void Render(FrameEventArgs e)
        {
            if (RootElement != null)
            {
                RootElement.Render(e);
            }            
        }

        public void Resize(int width, int height)
        {
            ClientWidth = width;
            ClientHeight = height;
            if (RootElement != null)
            {
                RootElement.Resize();
            }
        }
    }
}
