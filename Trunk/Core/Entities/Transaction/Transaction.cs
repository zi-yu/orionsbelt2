	// WARNING: Generated File! Do not modify by hand!
	// *************************************************************

using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Loki.DataRepresentation;
using Loki;

namespace OrionsBelt.Core {
	//[Serializable()]
	public abstract partial class Transaction : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string transactionContext;
		private int principalIdSpend;
		private string identityTypeSpend;
		private int identifierSpend;
		private int creditsSpend;
		private int spendCurrentCredits;
		private string identityTypeGain;
		private int identifierGain;
		private int creditsGain;
		private int gainCurrentCredits;
		private int tick;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Transaction's TransactionContext
        /// </summary>
		public virtual string TransactionContext {
			set{ this.transactionContext = value;}
			get{ return this.transactionContext;}
		}

		/// <summary>
        /// Gets the Transaction's PrincipalIdSpend
        /// </summary>
		public virtual int PrincipalIdSpend {
			set{ this.principalIdSpend = value;}
			get{ return this.principalIdSpend;}
		}

		/// <summary>
        /// Gets the Transaction's IdentityTypeSpend
        /// </summary>
		public virtual string IdentityTypeSpend {
			set{ this.identityTypeSpend = value;}
			get{ return this.identityTypeSpend;}
		}

		/// <summary>
        /// Gets the Transaction's IdentifierSpend
        /// </summary>
		public virtual int IdentifierSpend {
			set{ this.identifierSpend = value;}
			get{ return this.identifierSpend;}
		}

		/// <summary>
        /// Gets the Transaction's CreditsSpend
        /// </summary>
		public virtual int CreditsSpend {
			set{ this.creditsSpend = value;}
			get{ return this.creditsSpend;}
		}

		/// <summary>
        /// Gets the Transaction's SpendCurrentCredits
        /// </summary>
		public virtual int SpendCurrentCredits {
			set{ this.spendCurrentCredits = value;}
			get{ return this.spendCurrentCredits;}
		}

		/// <summary>
        /// Gets the Transaction's IdentityTypeGain
        /// </summary>
		public virtual string IdentityTypeGain {
			set{ this.identityTypeGain = value;}
			get{ return this.identityTypeGain;}
		}

		/// <summary>
        /// Gets the Transaction's IdentifierGain
        /// </summary>
		public virtual int IdentifierGain {
			set{ this.identifierGain = value;}
			get{ return this.identifierGain;}
		}

		/// <summary>
        /// Gets the Transaction's CreditsGain
        /// </summary>
		public virtual int CreditsGain {
			set{ this.creditsGain = value;}
			get{ return this.creditsGain;}
		}

		/// <summary>
        /// Gets the Transaction's GainCurrentCredits
        /// </summary>
		public virtual int GainCurrentCredits {
			set{ this.gainCurrentCredits = value;}
			get{ return this.gainCurrentCredits;}
		}

		/// <summary>
        /// Gets the Transaction's Tick
        /// </summary>
		public virtual int Tick {
			set{ this.tick = value;}
			get{ return this.tick;}
		}

		/// <summary>
        /// Gets the Transaction's Invoice
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<Invoice> Invoice {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Transaction) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("{0}:{1}", TypeName, Id);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = TransactionContext.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TransactionContext\" : \"{0}\", ", str);
			str = PrincipalIdSpend.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PrincipalIdSpend\" : \"{0}\", ", str);
			str = IdentityTypeSpend.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IdentityTypeSpend\" : \"{0}\", ", str);
			str = IdentifierSpend.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IdentifierSpend\" : \"{0}\", ", str);
			str = CreditsSpend.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CreditsSpend\" : \"{0}\", ", str);
			str = SpendCurrentCredits.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SpendCurrentCredits\" : \"{0}\", ", str);
			str = IdentityTypeGain.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IdentityTypeGain\" : \"{0}\", ", str);
			str = IdentifierGain.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IdentifierGain\" : \"{0}\", ", str);
			str = CreditsGain.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CreditsGain\" : \"{0}\", ", str);
			str = GainCurrentCredits.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"GainCurrentCredits\" : \"{0}\", ", str);
			str = Tick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Tick\" : \"{0}\", ", str);
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
			get { return "Transaction"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Transaction other = obj as Transaction;
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
			return string.Format("{0}:{1}", TypeName, Id);
		}
		
		#endregion Overrided Members
		
	};
}
