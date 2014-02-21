
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.WebComponents.Controls {

    /// <summary>
    /// Renders in XHTML the content of a MediaArticle's LastActionUserId
    /// </summary>
	public class MediaArticleLastActionUserId : BaseFieldControl<MediaArticle>, INamingContainer {
	
		#region BaseFieldControl<MediaArticle> Implementation
		
		/// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, MediaArticle entity, int renderCount, bool flipFlop )
		{
			writer.Write( entity.LastActionUserId );
		}
		
		#endregion BaseFieldControl<MediaArticle> Implementation
		
	};

}
