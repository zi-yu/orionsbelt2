using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Language.WebComponents.Controls;
using Language.Core;
using System.Collections;
using Language.WebComponents;
using Loki.DataRepresentation;
using Language.DataAccessLayer;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace Language.WebUserInterface.Controls {

    public class LanguageTranslationTextEditor : Language.WebComponents.Controls.LanguageTranslationTextEditor {

        #region Rendering

        public override void Update(LanguageTranslation entity)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(string.Format("<root>{0}</root>",text.Text));
            

            base.Update(entity);
        }
        

        #endregion Rendering

    };
}
