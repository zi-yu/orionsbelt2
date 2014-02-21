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
    /// Edits the Regist of the GroupPointsStorage entity
    /// </summary>
	public class GroupPointsStorageRegistEditor : 
			PrincipalTournamentItem, IEntityFieldEditor<GroupPointsStorage>, INamingContainer {

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

		#region PrincipalTournamentItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PrincipalTournament GetSourceFromParent( IDescriptable descriptable )
        {
            GroupPointsStorage entity = descriptable as GroupPointsStorage;
            if (entity == null) {
                return null;
            }
            return entity.Regist;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "GroupPointsStorageRegist";
		}
		
		#endregion Control unique identifier
		
		#endregion PrincipalTournamentItem Implementation
		

		#region IEntityFieldEditor<PrincipalTournament> Implementation
		
		/// <summary>
        /// Updates an GroupPointsStorage
        /// </summary>
        /// <param name="entity">An instance of GroupPointsStorage</param>
		public void Update( GroupPointsStorage entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Regist = Current;
		}
		
		#endregion IEntityFieldEditor<PrincipalTournament> Implementation
		
	};

}
