using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Team of the Principal entity
    /// </summary>
	public class PrincipalTeamEditor : 
			TeamStorageItem, IEntityFieldEditor<Principal>, INamingContainer {

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

		#region TeamStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override TeamStorage GetSourceFromParent( IDescriptable descriptable )
        {
            Principal entity = descriptable as Principal;
            if (entity == null) {
                return null;
            }
            return entity.Team;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "PrincipalTeam";
		}
		
		#endregion Control unique identifier
		
		#endregion TeamStorageItem Implementation
		

		#region IEntityFieldEditor<TeamStorage> Implementation
		
		/// <summary>
        /// Updates an Principal
        /// </summary>
        /// <param name="entity">An instance of Principal</param>
		public void Update( Principal entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Team = Current;
		}
		
		#endregion IEntityFieldEditor<TeamStorage> Implementation
		
	};

}
