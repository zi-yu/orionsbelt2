using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Resources;
using System.Reflection;

namespace Institutional.WebComponents.Controls {
	public class Label : Control {
		
		#region Fields

		private string key = null;
		private object[] args = null;

		#endregion

		#region Properties

		public string Key {
			get { return key; }
			set { key = value; }
		}
		
		public object[] Args {
            get { return args; }
            set { args = value; }
        }

		#endregion

		#region Overriden
		
		protected override void Render( HtmlTextWriter writer ) 
		{
			try {
                string token = LanguageManager.Instance.Get(Key);
                if (Args != null) {
                    token = string.Format(token, Args);
                }
				writer.Write( token );
			} catch( Exception ex ) {
				writer.Write("@(Error for localized {0})", Key);
				writer.Write("<!-- {0} -->", ex.ToString());
			}
		} 

		#endregion
		
		#region Utilities

        public void SetArgs(params object[] args)
        {
            this.Args = args;
        }

        #endregion Utilities
		
	};
}
