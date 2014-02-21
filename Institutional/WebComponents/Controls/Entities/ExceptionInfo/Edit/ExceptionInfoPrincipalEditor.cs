using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Edits the Principal of the ExceptionInfo entity
    /// </summary>
	public class ExceptionInfoPrincipalEditor : 
			PrincipalItem, IEntityFieldEditor<ExceptionInfo>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region PrincipalItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Principal GetSourceFromParent( IDescriptable descriptable )
        {
            ExceptionInfo entity = descriptable as ExceptionInfo;
            if (entity == null) {
                return null;
            }
            return entity.Principal;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ExceptionInfoPrincipal";
		}
		
		#endregion Control unique identifier
		
		#endregion PrincipalItem Implementation
		

		#region IEntityFieldEditor<Principal> Implementation
		
		/// <summary>
        /// Updates an ExceptionInfo
        /// </summary>
        /// <param name="entity">An instance of ExceptionInfo</param>
		public void Update( ExceptionInfo entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Principal = Current;
		}
		
		#endregion IEntityFieldEditor<Principal> Implementation
		
	};

}
