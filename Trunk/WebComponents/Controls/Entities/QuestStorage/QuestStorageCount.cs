
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of QuestStorage in the data source
    /// </summary>
	public class QuestStorageCount : BaseEntityCount<QuestStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public QuestStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetQuestStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}