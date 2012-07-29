using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GameBrowser.DOM.Element;

namespace GameBrowser.DOM
{
    public class DOMTreeBuilder
    {
        public DOMTree Build(string sourcePath)
        {
            var reader = new XmlTextReader("../../game.xml");
            var source = new XmlDocument();
            source.Load(reader);
            reader.Close();

            var rootNode = source.GetElementsByTagName("game")[0];

            return new DOMTree
            {
                RootElement = CreateElement(rootNode)
            };
        }

        private IDOMElement CreateElement(XmlNode node)
        {
            var element = CreateActualElement(node);
            foreach (XmlNode child in node.ChildNodes)
            {
                element.Children.Add(CreateElement(child));
            }
            return element;
        }

        private IDOMElement CreateActualElement(XmlNode node)
        {
            switch (node.Name)
            {
                case "game":
                    return new GameDOMElement();
                case "style":
                    return new StyleDOMElement();
                case "viewport":
                    return new ViewportDOMElement();
                case "camera":
                    return new CameraDOMElement();
                case "box":
                    return new BoxDOMElement();
                default:
                    return new DummyDOMElement();
            }
        }
    }
}
