using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// This is the base class for controls that edit an Entity field
    /// </summary>
    /// <typeparam name="T">The Entity Type</typeparam>
	public abstract class BaseEntityFieldEditor<T> : 
			BaseFieldControl<T>,
			IEntityFieldEditor<T>
			where T : IDescriptable {
		
		#region Abstract Members
		
		/// <summary>
        /// Updates the object
        /// </summary>
        /// <param name="t">The object</param>
		public abstract void Update( T t );
		
		#endregion
		
	};

}