	// WARNING: Generated File! Do not modify by hand!
	// *************************************************************

using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace Institutional.Core {
	//[Serializable()]
	public abstract partial class Principal : Institutional.Core.Entity, IDescriptable, IComparable ,System.Security.Principal.IPrincipal  {

		#region Fields

		private string name;
		private string password;
		private string email;
		private string ip;
		private DateTime registDate = DateTime.Now;
		private DateTime lastLogin = DateTime.Now;
		private bool approved;
		private bool isOnline;
		private bool locked;
		private string locale;
		private string confirmationCode;
		private string rawRoles;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Principal's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Principal's Password
        /// </summary>
		public virtual string Password {
			set{ this.password = value;}
			get{ return this.password;}
		}

		/// <summary>
        /// Gets the Principal's Email
        /// </summary>
		public virtual string Email {
			set{ this.email = value;}
			get{ return this.email;}
		}

		/// <summary>
        /// Gets the Principal's Ip
        /// </summary>
		public virtual string Ip {
			set{ this.ip = value;}
			get{ return this.ip;}
		}

		/// <summary>
        /// Gets the Principal's RegistDate
        /// </summary>
		public virtual DateTime RegistDate {
			set{ this.registDate = value;}
			get{ return this.registDate;}
		}

		/// <summary>
        /// Gets the Principal's LastLogin
        /// </summary>
		public virtual DateTime LastLogin {
			set{ this.lastLogin = value;}
			get{ return this.lastLogin;}
		}

		/// <summary>
        /// Gets the Principal's Approved
        /// </summary>
		public virtual bool Approved {
			set{ this.approved = value;}
			get{ return this.approved;}
		}

		/// <summary>
        /// Gets the Principal's IsOnline
        /// </summary>
		public virtual bool IsOnline {
			set{ this.isOnline = value;}
			get{ return this.isOnline;}
		}

		/// <summary>
        /// Gets the Principal's Locked
        /// </summary>
		public virtual bool Locked {
			set{ this.locked = value;}
			get{ return this.locked;}
		}

		/// <summary>
        /// Gets the Principal's Locale
        /// </summary>
		public virtual string Locale {
			set{ this.locale = value;}
			get{ return this.locale;}
		}

		/// <summary>
        /// Gets the Principal's ConfirmationCode
        /// </summary>
		public virtual string ConfirmationCode {
			set{ this.confirmationCode = value;}
			get{ return this.confirmationCode;}
		}

		/// <summary>
        /// Gets the Principal's RawRoles
        /// </summary>
		public virtual string RawRoles {
			set{ this.rawRoles = value;}
			get{ return this.rawRoles;}
		}

		/// <summary>
        /// Gets the Principal's Exceptions
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ExceptionInfo> Exceptions {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Principal) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Name);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Password.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Password\" : \"{0}\", ", str);
			str = Email.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Email\" : \"{0}\", ", str);
			str = Ip.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Ip\" : \"{0}\", ", str);
			str = RegistDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RegistDate\" : \"{0}\", ", str);
			str = LastLogin.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastLogin\" : \"{0}\", ", str);
			str = Approved.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Approved\" : \"{0}\", ", str);
			str = IsOnline.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsOnline\" : \"{0}\", ", str);
			str = Locked.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locked\" : \"{0}\", ", str);
			str = Locale.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Locale\" : \"{0}\", ", str);
			str = ConfirmationCode.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ConfirmationCode\" : \"{0}\", ", str);
			str = RawRoles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RawRoles\" : \"{0}\", ", str);
			str = CreatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CreatedDate\" : \"{0}\", ", str);
			str = UpdatedDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UpdatedDate\" : \"{0}\", ", str);
			str = LastActionUserId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastActionUserId\" : \"{0}\", ", str);
			writer.Write("\"TypeName\" : \"{0}\" ", TypeName);
			writer.Write("}");
			return writer.ToString();
		}

		public override string TypeName { 
			get { return "Principal"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Principal other = obj as Principal;
			if( other == null ) {
				// we don't know how to compare diferent entities
				return 0;
			}
			
			return other.Id.CompareTo(this.Id);
		}

		#endregion IComparable Implementation

		#region Overrided Members
		
		public override string ToString()
		{
			if( Name == null ) {
				return string.Empty;
			}
			return Name.ToString();
		}
		
		#endregion Overrided Members
		
		#region IPrincipal Members
		
		/// <summary>
        /// The correct display name
        /// </summary>
        public string DisplayName {
            get { 
                try {
                    int idx = Name.LastIndexOf(":");
                    if (idx < 0) {
                        return Name;
                    }
                    idx += 1;
                    return Name.Substring(idx, Name.Length - idx); 
                } catch( Exception ex ) {
                    return Name;
                }
            }
        }

		System.Security.Principal.IIdentity identity = null;

		[XmlIgnore()]
		public virtual System.Security.Principal.IIdentity Identity {
			get { return identity; }
			set { identity = value; }
		}
		
		private static readonly char[] RolesSeparator = {','};
        private IEnumerable<string> roles = null;
        [XmlIgnore()]
        public virtual IEnumerable<string> Roles {
            get {
                if (roles == null) {
                    if (!string.IsNullOrEmpty(RawRoles)) {
                        roles = RawRoles.Split(RolesSeparator, StringSplitOptions.RemoveEmptyEntries);
                    }
                    if (roles == null) {
                        roles = new string[0];
                    }
                }
                return roles; 
            }
            set { 
                roles = value; 
            }
        }

		public virtual bool IsInRole( string role ) {
			if( string.IsNullOrEmpty( role ) ) {
				return false;
			}
			if( role == "user" ) {
				return true;
			}
			return RoleManager.IsInRole(role, Roles);
		}

		#endregion
		
	};
}
