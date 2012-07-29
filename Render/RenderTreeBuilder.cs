using GameBrowser.DOM;
using GameBrowser.DOM.Element;
using GameBrowser.Style;
using GameBrowser.Render.Element;

namespace GameBrowser.Render
{
    public class RenderTreeBuilder
    {
        private RenderTree m_renderTree;
        private StyleRules m_styleRules;

        public RenderTree Build(DOMTree domTree, StyleRules styleRules)
        {
            m_styleRules = styleRules;
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
                    return CreateBoxElement(domElement);
                default:
                    return new DummyRenderElement(m_renderTree);
            }
        }

        private BoxRenderElement CreateBoxElement(IDOMElement domElement)
        {
            var boxElement = new BoxRenderElement(m_renderTree);
            foreach (var styleRule in m_styleRules.Items)
            {
                if (styleRule.Selector == domElement.TagName)
                {
                    foreach(var rule in styleRule.Rules)
                    {
                        if (rule.Key == "color")
                        {
                            boxElement.Color = double.Parse(rule.Value);
                        }
                    }
                }
            }
            return boxElement;
        }
    }
}
