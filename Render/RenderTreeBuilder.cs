using GameBrowser.DOM;
using GameBrowser.DOM.Element;
using GameBrowser.Render.Element;

namespace GameBrowser.Render
{
    public class RenderTreeBuilder
    {
        private RenderTree m_renderTree;

        public RenderTree Build(DOMTree domTree)
        {
            m_renderTree = new RenderTree();
            m_renderTree.RootElement = CreateElement(domTree.RootElement);
            return m_renderTree;
        }

        private IRenderElement CreateElement(IDOMElement domElement)
        {
            var element = CreateActualElement(domElement);
            foreach (var child in domElement.Children)
            {
                element.Children.Add(CreateElement(child));
            }
            return element;
        }

        private IRenderElement CreateActualElement(IDOMElement domElement)
        {
            switch (domElement.TagName)
            {
                case "viewport":
                    return new ViewportRenderElement(m_renderTree);
                case "camera":
                    return new CameraRenderElement(m_renderTree);
                case "box":
                    return new BoxRenderElement(m_renderTree);
                default:
                    return new DummyRenderElement(m_renderTree);
            }
        }
    }
}
