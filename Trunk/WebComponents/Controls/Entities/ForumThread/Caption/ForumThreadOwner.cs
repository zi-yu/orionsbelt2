﻿
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a ForumThread's Owner
    /// </summary>
	public class ForumThreadOwner : BaseFieldControl<ForumThread>, INamingContainer {
	
		#region Control Fields & Properties
		
		private string url = "#";
		private string urlText = string.Empty;
		private bool includeUrl = true;

        /// <summary>
        /// URL text to show in the link
        /// </summary>
        public string UrlText
        {
            get { return urlText; }
            set { urlText = value; }
        }
			
		/// <summary>
        /// URL to show this object's detail
        /// </summary>
		public string Url {
			get { return url; }
			set { url = value; }
		}

		/// <summary>
        /// If the control should use Url/UrlText or just write the entity
        /// </summary>
        public bool IncludeUrl {
            get { return includeUrl; }
            set { includeUrl = value; }
        }
		
		#endregion Control Fields
		
		#region BaseFieldControl<ForumThread> Implementation
		
		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, ForumThread entity, int renderCount, bool flipFlop )
		{
			if ( entity.Owner == null ) {
                return;
            }
            if (!IncludeUrl) {
				string caption = entity.Owner.ToString();
                writer.Write( caption );
                return;
            }
			string urlToShow = urlText != string.Empty ? urlText : entity.Owner.ToString();
			writer.Write( "<a href=\"{0}?PlayerStorage={2}\">{1}</a>", 
						Url, urlToShow,
						entity.Owner.Id 
				);
		}
		
		#endregion BaseFieldControl<ForumThread> Implementation
		
	};

}
