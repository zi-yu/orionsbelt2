
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ExceptionInfo in the data source
    /// </summary>
	public class ExceptionInfoCount : BaseEntityCount<ExceptionInfo> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ExceptionInfoCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetExceptionInfoPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}