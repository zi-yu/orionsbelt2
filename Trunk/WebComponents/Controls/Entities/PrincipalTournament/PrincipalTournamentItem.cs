
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PrincipalTournament control renderer
    /// </summary>
	public class PrincipalTournamentItem : BaseEntityItem<PrincipalTournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalTournamentItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalTournamentPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasEliminated</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentHasEliminated () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EliminatedInFase</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentEliminatedInFase () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EliminatedInBattleId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentEliminatedInBattleId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentPrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Tournament</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentTournament () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Team</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentTeam () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTournamentLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PrincipalTournament> Implementation
		
	};

}
