using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Web.Security;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace OrionsBelt.WebComponents {
	public class MidgardUserProvider : MembershipProvider {
	
		#region Fields

		private string applicationName = "MidgardUserProvider";

		#endregion

		#region Private

		protected static MembershipUserCollection ConvertToMembershipUser( IList<Principal> principals ) {
			MembershipUserCollection muc = new MembershipUserCollection();
			foreach( Principal p in principals ) {
				MembershipUser user = new MembershipUser(
					"MidgardUserProvider",
					p.Name,
					p.Id,
					p.Email,
					"",
					"",
					p.Approved,
					p.Locked,
					p.RegistDate,
					p.LastLogin,
					p.LastLogin,
					p.RegistDate,
					p.RegistDate
				);
				muc.Add( user );
			}
			return muc;
		}

		protected static int GenerateRandInt( int minValue, int maxValue ) {
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] b = new byte[1];
			rng.GetBytes( b );
			Random random = new Random( Convert.ToInt32( b[0] ) );
			return random.Next( minValue, maxValue + 1 );
		}

		protected static string GeneratePassword() {
			string newPassword = string.Empty;
			for( int i = 0 ; i < 8 ; ++i ) {
				newPassword += (char)GenerateRandInt( 97, 122 );
			}
			return newPassword;
		}
		
		protected string GenerateConfirmationCode(string username, string email){
            return Hash(username + email + "jervasio");
        }

		protected static string Hash( string value ) {
			return FormsAuthentication.HashPasswordForStoringInConfigFile( value, "sha1" );
		}

		protected static void SetLanguage( string lang ) {
			if( string.IsNullOrEmpty(lang) ) {
				lang = "en";
			}
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
		}

		#endregion

		#region AbstractMembers from MembershipProvider

		public override bool ChangePassword( string username, string oldPassword, string newPassword ) {
			using( IPrincipalPersistance principal = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = principal.SelectByName( username );
				if( p != null && p.Count > 0 ) {

					if( p[0].Password == Hash(oldPassword) ) {
						p[0].Password = Hash(newPassword);
						principal.Update( p[0] );
						return true;
					}
				}
				return false;
			}
		}

		public override MembershipUser CreateUser( string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status ) {
		    Principal principal = CreatePrincipal(username, password, email, isApproved, out status);
            if(null == principal)
            {
                return null;
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

        protected virtual Principal CreatePrincipal(string username, string password, string email, bool isApproved, out MembershipCreateStatus status)
        {
            Principal principal;
            using (IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance())
            {
                if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    status = MembershipCreateStatus.InvalidEmail;
                    return null;
                }

                if (principalPersistance.SelectByEmail(email).Count > 0)
                {
                    status = MembershipCreateStatus.DuplicateEmail;
                    return null;
                }

                if (principalPersistance.SelectByName(username).Count > 0)
                {
                    status = MembershipCreateStatus.InvalidUserName;
                    return null;
                }

                principal = principalPersistance.Create();
                principal.Name = username;
                principal.Password = Hash(password);
                principal.Email = email;
                principal.Approved = isApproved;
                principal.RegistDate = DateTime.Now;

                principalPersistance.Update(principal);
                principalPersistance.Flush();
                status = MembershipCreateStatus.Success;
                return principal;
            }
        }
		
		public virtual MembershipCreateStatus CreateUser(string username, string password, string email)
        {
            return CreateUser(username, password, email, string.Empty);
        }
		
		public virtual MembershipCreateStatus CreateUser(string username, string password, string email, string lang) {
            using (IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance()){
                if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")){
                    return MembershipCreateStatus.InvalidEmail;
                }

                if (principalPersistance.SelectByEmail(email).Count > 0){
                    return MembershipCreateStatus.DuplicateEmail;
                }

                if (principalPersistance.SelectByName(username).Count > 0){
                    return MembershipCreateStatus.InvalidUserName;
                }

                Principal principal = principalPersistance.Create();
                principal.Name = username;
                principal.Password = Hash(password);
                principal.Email = email;
                principal.Approved = false;
                principal.RegistDate = DateTime.Now;
                //principal.ConfirmationCode = GenerateConfirmationCode(username, email);

                //SendMail.Send(email, "noreply@zi-yu.com", LanguageManager.GetContent("registerConfirmation"), LanguageManager.GetContent("confirmationEmail"), username, principal.ConfirmationCode, email, password);

                principalPersistance.Update(principal);

                return MembershipCreateStatus.Success;
            }
        }

		public override bool DeleteUser( string username, bool deleteAllRelatedData ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = principalPersistance.SelectByName( username );
				if( p != null && p.Count > 0 ) {
					principalPersistance.Delete( p[0] );
					return true;
				}
				return false;
			}
		}

		public override MembershipUserCollection FindUsersByEmail( string emailToMatch, int pageIndex, int pageSize, out int totalRecords ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				List<Principal> principals = (List<Principal>) principalPersistance.SelectByEmail(emailToMatch);
				principals = principals.GetRange( (pageIndex - 1) * pageSize, pageSize );
				MembershipUserCollection muc = ConvertToMembershipUser( principals );
				totalRecords = muc.Count;
				return muc;
			}
		}

		public override MembershipUserCollection FindUsersByName( string usernameToMatch, int pageIndex, int pageSize, out int totalRecords ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				List<Principal> principals = (List<Principal>) principalPersistance.SelectByName( usernameToMatch );
				principals = principals.GetRange( ( pageIndex - 1 ) * pageSize, pageSize );
				MembershipUserCollection muc = ConvertToMembershipUser( principals );
				totalRecords = muc.Count;
				return muc;
			}
		}

		public override MembershipUserCollection GetAllUsers( int pageIndex, int pageSize, out int totalRecords ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> principals = principalPersistance.Select( ( pageIndex - 1 ) * pageSize, pageSize );
				MembershipUserCollection muc = ConvertToMembershipUser( principals );
				totalRecords = muc.Count;
				return muc;
			}
		}

		public override int GetNumberOfUsersOnline() {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				return principalPersistance.SelectByIsOnline( true ).Count;
			}
		}

		public override MembershipUser GetUser( string username, bool userIsOnline ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> principals = principalPersistance.SelectByName( username );
				if( principals != null && principals.Count > 0 ) {
					Principal p = principals[0];
					return new MembershipUser(
						"MidgardUserProvider",
						p.Name,
						p.Id,
						p.Email,
						"",
						"",
						p.Approved,
						p.Locked,
						p.RegistDate,
						p.LastLogin,
						p.LastLogin,
						p.RegistDate,
						p.RegistDate
					);
				}
				return null;
			}
		}

		public override MembershipUser GetUser( object providerUserKey, bool userIsOnline ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public override string GetUserNameByEmail( string email ) {
			using( IPrincipalPersistance principal = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = principal.SelectByEmail( email );
				if( p != null && p.Count > 0 ) {
					return p[0].Name;
				}
				return string.Empty;
			}
		}

		public override string ResetPassword( string username, string answer ) {
			using( IPrincipalPersistance principal = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = principal.SelectByName( username );
				if( p != null && p.Count > 0 ) {
					p[0].Password = GeneratePassword();
					principal.Update( p[0] );
					return p[0].Password;
				}
				return string.Empty;
			}
		}

		public override bool UnlockUser( string userName ) {
			using( IPrincipalPersistance principal = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> p = principal.SelectByName( userName );
				if( p != null && p.Count > 0 ) {
					p[0].Locked = false;
					principal.Update( p[0] );
					return true;
				}
				return false;
			}
		}

		public override void UpdateUser( MembershipUser user ) {
			using( IPrincipalPersistance principalPersistance = Persistance.Instance.GetPrincipalPersistance() ) {
				IList<Principal> principals = principalPersistance.SelectByEmail( user.Email );
				if( principals != null && principals.Count > 0 ) {
					Principal p = principals[0];
					p.Name = user.UserName;
					p.Email = user.Email;
					p.Approved = user.IsApproved;
					p.Locked = user.IsLockedOut;
					p.RegistDate = user.CreationDate;
					p.LastLogin = user.LastLoginDate;
					principalPersistance.Update( p );
				}
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
						State.SetUserInMemory(username, user);

						return true;
					}					
				}
				return false;
			}
		}

		public override bool ChangePasswordQuestionAndAnswer( string username, string password, string newPasswordQuestion, string newPasswordAnswer ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public override string GetPassword( string username, string answer ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		#region Properties

		public override string ApplicationName {
			get { return applicationName; }
			set { applicationName = value; }
		}

		public override string PasswordStrengthRegularExpression {
			get { throw new Exception( "The method or operation is not implemented." ); }
		}

		public override bool RequiresQuestionAndAnswer {
			get { return false; }
		}

		public override bool RequiresUniqueEmail {
			get { return true; }
		}

		public override int MaxInvalidPasswordAttempts {
			get { return 5; }
		}

		public override int MinRequiredNonAlphanumericCharacters {
			get { return 0; }
		}

		public override int MinRequiredPasswordLength {
			get { return 3; }
		}

		public override int PasswordAttemptWindow {
			get { return 30; }
		}

		public override MembershipPasswordFormat PasswordFormat {
			get { return MembershipPasswordFormat.Hashed; }
		}

		public override bool EnablePasswordReset {
			get { return true; }
		}

		public override bool EnablePasswordRetrieval {
			get { return false; }
		}

		#endregion

		#endregion
	}
}
