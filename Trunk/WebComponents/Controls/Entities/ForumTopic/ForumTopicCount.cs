
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ForumTopic in the data source
    /// </summary>
	public class ForumTopicCount : BaseEntityCount<ForumTopic> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumTopicCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumTopicPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}