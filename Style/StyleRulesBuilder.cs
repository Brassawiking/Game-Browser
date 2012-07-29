using GameBrowser.DOM;
using GameBrowser.DOM.Element;

namespace GameBrowser.Style
{
    public class StyleRulesBuilder
    {
        private StyleRules m_styleRules;

        public StyleRules Build(DOMTree domTree)
        {
            m_styleRules = new StyleRules();
            GatherStyles(domTree.RootElement);
            return m_styleRules;
        }

        private void GatherStyles(IDOMElement domElement)
        {
            if (domElement.TagName == "style")
            {
                foreach (var child in domElement.Children)
                {
                    GetStyleRules((StyleRuleDOMElement)child);
                }
            }
            else
            {
                foreach (var child in domElement.Children)
                {
                    GatherStyles(child);
                }
            }
        }

        private void GetStyleRules(StyleRuleDOMElement styleRuleElement)
        {
            m_styleRules.Items.Add(new StyleRule
            {
                Selector = styleRuleElement.Selector,
                Rules = styleRuleElement.Rules
            });
        }

    }
}
