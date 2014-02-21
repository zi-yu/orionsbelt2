using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine.MarketPlace;
using System.Collections.Generic;
using System.Security.Principal;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface
{
    public class OBUserProvider: MidgardUserProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            Principal principal = CreatePrincipal(username, password, email, isApproved, out status);
            
            InitPrincipal(principal,username, password, email, string.Empty);

            string sList = ConfigurationManager.AppSettings["bonusList"];
            IList<string> bList = new List<string>(sList.Split(','));
            if (State.HasItems("Referrer") &&
                    bList.Contains(State.GetItems("Referrer").ToString()))
            {
                TransactionManager.RegistTransaction(principal, 250);
            }

            return new MembershipUser(
                "Midgard",
                username,
                providerUserKey,
                email,
                "",
                "",
                isApproved,
                principal.Locked,
                principal.RegistDate,
                principal.RegistDate,
                principal.RegistDate,
                principal.RegistDate,
                principal.RegistDate
                );

        }

        private void InitPrincipal(Principal principal,string username, string password, string email, string lang)
        {
            using (IPrincipalPersistance ladderPersistance = Persistance.Instance.GetPrincipalPersistance())
            {
                ladderPersistance.StartTransaction();

                int ladderPos = (int)ladderPersistance.ExecuteScalar("select max(info.LadderPosition) from SpecializedPrincipal info") + 1;
                int idStats;
                using (IPrincipalStatsPersistance stats = Persistance.Instance.GetPrincipalStatsPersistance(ladderPersistance))
                {
                    PrincipalStats newStats = stats.Create();
                    newStats.MaxElo = 1000;
                    newStats.MinElo = 1000;
                    newStats.NumberPlayedBattles = 0;
                    newStats.MaxLadder = ladderPos;
                    newStats.MinLadder = ladderPos;
                    stats.Update(newStats);
                    idStats = newStats.Id;
                }
                
                principal.Name = username;
                principal.Password = Hash(password);
                principal.Email = email;
                principal.Locale = lang;
                principal.Approved = false;
                principal.ConfirmationCode = GenerateConfirmationCode(username, email);
                principal.RegistDate = DateTime.Now;
                principal.AvailableVacationTicks = 1000;
                principal.EloRanking = 1000;
                principal.AcceptedTerms = true;
                principal.IsInBattle = 0;
                string sList = ConfigurationManager.AppSettings["bonusList"];
                IList<string> bList = new List<string>(sList.Split(','));
                //State.Items.Add("Referrer","-1000");
                if (State.HasItems("Referrer") &&
                    bList.Contains(State.GetItems("Referrer").ToString()))
                {
                    principal.Credits = 250;
                    //TransactionManager.RegistTransaction(principal, 250, ladderPersistance);
                }
                else
                {
                    principal.Credits = 0;
                }
                principal.LadderActive = true;
                principal.LadderPosition = ladderPos;
                principal.MyStatsId = idStats;
                ladderPersistance.Update(principal);

                CheckReferrer(principal);

                ladderPersistance.CommitTransaction();

            }
        }

        private void CheckReferrer(Principal principal)
        {
            if (State.HasItems("Referrer")) {
                int referrer = 0;
                if (int.TryParse(State.GetItems("Referrer").ToString(), out referrer)) {
                    principal.ReferrerId = referrer;
                }
            }
        }

		public override MembershipCreateStatus CreateUser(string username, string password, string email, string lang) {
			using (IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance()) {
                principalPersistance.StartTransaction();
				if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\+\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) {
					return MembershipCreateStatus.InvalidEmail;
				}

				if (principalPersistance.CountByEmail(email) > 0) {
					return MembershipCreateStatus.DuplicateEmail;
				}

				if (principalPersistance.CountByName(username) > 0) {
					return MembershipCreateStatus.InvalidUserName;
				}

                if (Convert.ToInt32(Hql.ExecuteScalar("select count(*) from SpecializedPlayerStorage player where player.Name = :name", Hql.Param("name", username))) > 0) {
                    return MembershipCreateStatus.InvalidUserName;
                }

				Principal principal = principalPersistance.Create();
			    InitPrincipal(principal, username, password, email,lang);

                principalPersistance.CommitTransaction();

                string sList = ConfigurationManager.AppSettings["bonusList"];
                IList<string> bList = new List<string>(sList.Split(','));
                if (State.HasItems("Referrer") &&
                    bList.Contains(State.GetItems("Referrer").ToString()))
                {
                    TransactionManager.RegistTransaction(principal, 250);
                }
				
//#if !DEBUG				
				MailSender.Send( email, "noreply@orionsbelt.eu", LanguageManager.Instance.Get("registerConfirmation"), LanguageManager.Instance.Get("confirmationEmail"), username, principal.ConfirmationCode, password, Server.Properties.BaseUrl);
//#endif

				return MembershipCreateStatus.Success;
			}
		}

		public Principal CreateBotUser(string username, string botUrl) {
			using (IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance()) {
				if (principalPersistance.SelectByName(username).Count > 0) {
					return null;
				}

				Principal principal = principalPersistance.Create();
                InitPrincipal(principal, username, GeneratePassword(), string.Empty,string.Empty);
				principal.IsBot = true;
				principal.BotUrl = botUrl;
				principal.LadderActive = false;
				principalPersistance.Update(principal);
				principalPersistance.Flush();

				return principal;
			}
		}

        public override bool ValidateUser( string username, string password ) {
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = persistance.SelectByName( username );
				if( p != null && p.Count > 0 ) {
					Principal user = p[0];
					if( user.Password == Hash( password ) ) {
						user.LastLogin = DateTime.Now;
						persistance.Update( user );
						persistance.Flush();

						SetLanguage(user.Locale);

						user.Identity = new GenericIdentity(user.Name, "FormsAuthentication");

						return true;
					}					
				}
				return false;
			}
		}

    }
}
