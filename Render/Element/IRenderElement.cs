using System.Collections.Generic;
using OpenTK;

namespace GameBrowser.Render.Element
{
    public class IRenderElement
    {
        public RenderTree RenderTree { get; set; }
        public IRenderElement Parent { get; set; }
        public IList<IRenderElement> Children { get; set; }
        public BoxModel Box { get; set; }

        public IRenderElement(RenderTree renderTree)
        {
            Children = new List<IRenderElement>();
            Box = new BoxModel();
            RenderTree = renderTree;
        }

        public virtual void Render(FrameEventArgs e)
        {
            foreach (var child in Children)
            {
                child.Render(e);
            }
        }

        public virtual void Resize()
        {
            foreach (var child in Children)
            {
                child.Resize();
            }
        }
    }
}
