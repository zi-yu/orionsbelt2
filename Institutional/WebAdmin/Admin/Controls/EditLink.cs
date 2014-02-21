
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Institutional.WebComponents.Controls;
using Loki.DataRepresentation;

namespace Institutional.WebAdmin.Admin.Controls {

    public class EditLink : Control {

        protected override void Render(HtmlTextWriter writer)
        {
            IDescriptableHandler handler = Parent as IDescriptableHandler;
            if (handler != null) {
                IDescriptable source = handler.Descriptable;
                writer.Write("<a href=\"{2}Edit.aspx?{0}={1}\">Edit</a>", source.TypeName, source.Id, source.TypeName.ToLower());
            } else {
                throw new Exception("Parent isn't IDescriptableHandler, it's " + Parent.GetType().Name);
            }
        }

    }

}