using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBrowser.DOM.Element
{
    public class StyleRuleDOMElement : IDOMElement
    {
        public override string TagName { get { return "stylerule"; } }
        public string Selector { get; set; }
        public Dictionary<string, string> Rules { get; set; }
    }
}
