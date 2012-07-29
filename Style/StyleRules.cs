using System.Collections.Generic;

namespace GameBrowser.Style
{
    public class StyleRules
    {
        public IList<StyleRule> Items { get; set; }

        public StyleRules()
        {
            Items = new List<StyleRule>();
        }
    }
}
