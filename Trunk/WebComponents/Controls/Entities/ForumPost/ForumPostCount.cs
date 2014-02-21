
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ForumPost in the data source
    /// </summary>
	public class ForumPostCount : BaseEntityCount<ForumPost> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumPostCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumPostPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}