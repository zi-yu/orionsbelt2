
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Tournament control renderer
    /// </summary>
	public class TournamentItem : BaseEntityItem<Tournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TournamentItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTournamentPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Tournament> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WarningTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentWarningTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Prize</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentPrize () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CostCredits</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentCostCredits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TournamentType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTournamentType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>FleetId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentFleetId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsPublic</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsPublic () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsSurvival</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsSurvival () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TurnTime</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTurnTime () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SubscriptionTime</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentSubscriptionTime () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MaxPlayers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMaxPlayers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MinPlayers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMinPlayers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NPlayersToPlayoff</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentNPlayersToPlayoff () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MaxElo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMaxElo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MinElo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMinElo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StartTime</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentStartTime () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentEndDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Token</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentToken () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TokenNumber</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTokenNumber () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsCustom</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsCustom () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PaymentsRequired</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentPaymentsRequired () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberPassGroup</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentNumberPassGroup () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>DescriptionToken</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentDescriptionToken () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Tournament> Implementation
		
	};

}
