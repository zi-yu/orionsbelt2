
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of MediaArticle in the data source
    /// </summary>
	public class MediaArticleCount : BaseEntityCount<MediaArticle> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MediaArticleCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetMediaArticlePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}