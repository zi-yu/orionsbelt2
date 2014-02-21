
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ExceptionInfo in the data source
    /// </summary>
	public class ExceptionInfoCount : BaseEntityCount<ExceptionInfo> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ExceptionInfoCount () : base( Institutional.DataAccessLayer.Persistance.Instance.GetExceptionInfoPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}