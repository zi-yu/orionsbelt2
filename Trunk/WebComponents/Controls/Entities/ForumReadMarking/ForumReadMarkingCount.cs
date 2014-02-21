
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ForumReadMarking in the data source
    /// </summary>
	public class ForumReadMarkingCount : BaseEntityCount<ForumReadMarking> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ForumReadMarkingCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetForumReadMarkingPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}