
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Tournament editor control
    /// </summary>
	public partial class TournamentEditor : BaseEntityEditor<Tournament> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TournamentEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTournamentPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WarningTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentWarningTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Prize</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentPrizeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CostCredits</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentCostCreditsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TournamentType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTournamentTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>FleetId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentFleetIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsPublic</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsPublicEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsSurvival</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsSurvivalEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TurnTime</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTurnTimeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SubscriptionTime</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentSubscriptionTimeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MaxPlayers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMaxPlayersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MinPlayers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMinPlayersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NPlayersToPlayoff</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentNPlayersToPlayoffEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MaxElo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMaxEloEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MinElo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentMinEloEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StartTime</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentStartTimeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentEndDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Token</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTokenEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TokenNumber</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentTokenNumberEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsCustom</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentIsCustomEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PaymentsRequired</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentPaymentsRequiredEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberPassGroup</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentNumberPassGroupEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>DescriptionToken</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentDescriptionTokenEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TournamentLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Tournament> Implementation
		
	};

}