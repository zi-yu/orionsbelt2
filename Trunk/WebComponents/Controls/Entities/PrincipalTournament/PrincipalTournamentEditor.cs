
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PrincipalTournament editor control
    /// </summary>
	public partial class PrincipalTournamentEditor : BaseEntityEditor<PrincipalTournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalTournamentEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalTournamentPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PrincipalTournament> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasEliminated</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentHasEliminatedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EliminatedInFase</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentEliminatedInFaseEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EliminatedInBattleId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentEliminatedInBattleIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Principal</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentPrincipalEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Tournament</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentTournamentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Team</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentTeamEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PrincipalTournament> Implementation
		
	};

}