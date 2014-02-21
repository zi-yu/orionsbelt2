using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MainForm : HtmlForm
    {
        protected bool _render;

        public bool RenderFormTag
        {
            get { return _render; }
            set { _render = value; }
        }

        public MainForm()
        {
            //By default, show the form tag
            _render = true;
        }

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            //Only render the tag when _render is set to true
            if (_render)
                base.RenderBeginTag(writer);
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            //Only render the tag when _render is set to true
            if (_render)
                base.RenderEndTag(writer);
        }
    }
}
