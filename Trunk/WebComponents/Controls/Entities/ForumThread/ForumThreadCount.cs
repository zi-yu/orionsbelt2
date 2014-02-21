
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ForumThread in the data source
    /// </summary>
	public class ForumThreadCount : BaseEntityCount<ForumThread> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumThreadCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumThreadPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}