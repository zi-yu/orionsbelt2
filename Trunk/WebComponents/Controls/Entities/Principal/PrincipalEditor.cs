
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Principal editor control
    /// </summary>
	public partial class PrincipalEditor : BaseEntityEditor<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Principal> Implementation

		/// <summary>
        /// Gets the current Principal
        /// </summary>
        /// <returns>The Principal</returns>
		protected override Principal GetSourceObject()
		{
			if( Source != SourceType.ContextUser ) {
				return base.GetSourceObject();
			}
			Principal principal = Context.User as Principal;
			if( principal == null ) {
				throw new Exception("Context.User it's not Principal");
			}
			return principal;
		}

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsBot</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsBotEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>MyStatsId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalMyStatsIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EloRanking</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEloRankingEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ReceiveMail</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReceiveMailEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Credits</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCreditsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LadderActive</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLadderActiveEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LadderPosition</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLadderPositionEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsInBattle</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsInBattleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RestUntil</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRestUntilEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>StoppedUntil</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStoppedUntilEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>AvailableVacationTicks</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAvailableVacationTicksEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VacationStartTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalVacationStartTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VacationEndtick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalVacationEndtickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>AutoStartVacations</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAutoStartVacationsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ReferrerId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReferrerIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CanChangeName</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCanChangeNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Avatar</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAvatarEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WebSite</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalWebSiteEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TutorialState</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTutorialStateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>DuplicatedIds</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalDuplicatedIdsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>NumberOfWarnings</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalNumberOfWarningsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>AcceptedTerms</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAcceptedTermsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>WarningPoints</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalWarningPointsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastWarningDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastWarningDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>BotUrl</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalBotUrlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ReferrerPriceCount</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReferrerPriceCountEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsOnVacations</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnVacationsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Team</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTeamEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Password</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalPasswordEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Email</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEmailEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Ip</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIpEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RegistDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRegistDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastLogin</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastLoginEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Approved</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalApprovedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsOnline</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnlineEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Locked</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLockedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Locale</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocaleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ConfirmationCode</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalConfirmationCodeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RawRoles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRawRolesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Principal> Implementation
		
	};

}