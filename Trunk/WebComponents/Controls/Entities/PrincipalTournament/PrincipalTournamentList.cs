
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of PrincipalTournament 
    /// </summary>
	public class PrincipalTournamentList : BaseList<PrincipalTournament> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the PrincipalTournament collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<PrincipalTournament> GetCollection()
		{
			using( IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<PrincipalTournament> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			PrincipalTournamentItem entity = new PrincipalTournamentItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"11\"> Listing <i>") );
			Controls.Add( new PrincipalTournamentCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>PrincipalTournament</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>HasEliminated</th>") );
			Controls.Add( new LiteralControl("<th>EliminatedInFase</th>") );
			Controls.Add( new LiteralControl("<th>EliminatedInBattleId</th>") );
			Controls.Add( new LiteralControl("<th>Principal</th>") );
			Controls.Add( new LiteralControl("<th>Tournament</th>") );
			Controls.Add( new LiteralControl("<th>Team</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new PrincipalTournamentDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentHasEliminated () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentEliminatedInFase () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentEliminatedInBattleId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentPrincipal () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentTournament () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentTeam () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PrincipalTournamentDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<PrincipalTournament> Implementation
		
	};

}