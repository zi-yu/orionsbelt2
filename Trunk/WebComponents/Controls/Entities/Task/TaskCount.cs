
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Task in the data source
    /// </summary>
	public class TaskCount : BaseEntityCount<Task> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TaskCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTaskPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}