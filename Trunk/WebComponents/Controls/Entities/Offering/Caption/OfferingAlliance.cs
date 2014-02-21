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
    /// Renders in XHTML the content of a Offering's Alliance
    /// </summary>
	public class OfferingAlliance : BaseFieldControl<Offering>, INamingContainer {
	
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
		
		#region BaseFieldControl<Offering> Implementation
		
		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, Offering entity, int renderCount, bool flipFlop )
		{
			if ( entity.Alliance == null ) {
                return;
            }
            if (!IncludeUrl) {
				string caption = entity.Alliance.ToString();
                writer.Write( caption );
                return;
            }
			string urlToShow = urlText != string.Empty ? urlText : entity.Alliance.ToString();
			writer.Write( "<a href=\"{0}?AllianceStorage={2}\">{1}</a>", 
						Url, urlToShow,
						entity.Alliance.Id 
				);
		}
		
		#endregion BaseFieldControl<Offering> Implementation
		
	};

}
