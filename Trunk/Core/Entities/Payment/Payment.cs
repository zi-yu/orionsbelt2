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
	public abstract partial class Payment : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int principalId;
		private string method;
		private string request;
		private string response;
		private string requestId;
		private string verifyState;
		private string parameters;
		private int parentPayment;
		private string ammount;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Payment's PrincipalId
        /// </summary>
		public virtual int PrincipalId {
			set{ this.principalId = value;}
			get{ return this.principalId;}
		}

		/// <summary>
        /// Gets the Payment's Method
        /// </summary>
		public virtual string Method {
			set{ this.method = value;}
			get{ return this.method;}
		}

		/// <summary>
        /// Gets the Payment's Request
        /// </summary>
		public virtual string Request {
			set{ this.request = value;}
			get{ return this.request;}
		}

		/// <summary>
        /// Gets the Payment's Response
        /// </summary>
		public virtual string Response {
			set{ this.response = value;}
			get{ return this.response;}
		}

		/// <summary>
        /// Gets the Payment's RequestId
        /// </summary>
		public virtual string RequestId {
			set{ this.requestId = value;}
			get{ return this.requestId;}
		}

		/// <summary>
        /// Gets the Payment's VerifyState
        /// </summary>
		public virtual string VerifyState {
			set{ this.verifyState = value;}
			get{ return this.verifyState;}
		}

		/// <summary>
        /// Gets the Payment's Parameters
        /// </summary>
		public virtual string Parameters {
			set{ this.parameters = value;}
			get{ return this.parameters;}
		}

		/// <summary>
        /// Gets the Payment's ParentPayment
        /// </summary>
		public virtual int ParentPayment {
			set{ this.parentPayment = value;}
			get{ return this.parentPayment;}
		}

		/// <summary>
        /// Gets the Payment's Ammount
        /// </summary>
		public virtual string Ammount {
			set{ this.ammount = value;}
			get{ return this.ammount;}
		}

		/// <summary>
        /// Gets the Payment's Invoice
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
			XmlSerializer serializer = new XmlSerializer( typeof(Payment) );
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
			str = PrincipalId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PrincipalId\" : \"{0}\", ", str);
			str = Method.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Method\" : \"{0}\", ", str);
			str = Request.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Request\" : \"{0}\", ", str);
			str = Response.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Response\" : \"{0}\", ", str);
			str = RequestId.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RequestId\" : \"{0}\", ", str);
			str = VerifyState.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VerifyState\" : \"{0}\", ", str);
			str = Parameters.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Parameters\" : \"{0}\", ", str);
			str = ParentPayment.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ParentPayment\" : \"{0}\", ", str);
			str = Ammount.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Ammount\" : \"{0}\", ", str);
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
			get { return "Payment"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Payment other = obj as Payment;
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
