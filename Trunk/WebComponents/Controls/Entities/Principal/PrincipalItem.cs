
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Principal control renderer
    /// </summary>
	public class PrincipalItem : BaseEntityItem<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Principal> Implementation

		/// <summary>
        /// Gets the current Principal to render
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsBot</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsBot () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>MyStatsId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalMyStatsId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EloRanking</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEloRanking () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ReceiveMail</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReceiveMail () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Credits</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCredits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LadderActive</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLadderActive () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LadderPosition</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLadderPosition () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsInBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RestUntil</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRestUntil () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StoppedUntil</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalStoppedUntil () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AvailableVacationTicks</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAvailableVacationTicks () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VacationStartTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalVacationStartTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VacationEndtick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalVacationEndtick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AutoStartVacations</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAutoStartVacations () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ReferrerId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReferrerId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CanChangeName</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCanChangeName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Avatar</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAvatar () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WebSite</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalWebSite () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TutorialState</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTutorialState () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>DuplicatedIds</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalDuplicatedIds () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>NumberOfWarnings</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalNumberOfWarnings () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AcceptedTerms</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalAcceptedTerms () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>WarningPoints</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalWarningPoints () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastWarningDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastWarningDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>BotUrl</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalBotUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ReferrerPriceCount</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalReferrerPriceCount () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsOnVacations</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnVacations () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Team</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalTeam () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Password</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalPassword () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Email</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEmail () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Ip</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIp () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RegistDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRegistDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastLogin</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastLogin () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Approved</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalApproved () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsOnline</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnline () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locked</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocked () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locale</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocale () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ConfirmationCode</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalConfirmationCode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RawRoles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRawRoles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Principal> Implementation
		
	};

}
