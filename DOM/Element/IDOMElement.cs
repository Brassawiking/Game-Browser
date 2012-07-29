using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBrowser.DOM.Element
{
    public class IDOMElement
    {
        public IDOMElement Parent { get; set; }
        public IList<IDOMElement> Children { get; set; }

        public virtual string TagName { get { return ""; } }
        public string ID { get; set; }
        public IList<string> Class { get; set; }

        public IDOMElement()
        {
            Children = new List<IDOMElement>();
        }
    }
}
