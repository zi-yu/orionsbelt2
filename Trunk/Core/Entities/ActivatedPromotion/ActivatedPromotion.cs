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
	public abstract partial class ActivatedPromotion : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private bool used;
		private string code;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ActivatedPromotion's Used
        /// </summary>
		public virtual bool Used {
			set{ this.used = value;}
			get{ return this.used;}
		}

		/// <summary>
        /// Gets the ActivatedPromotion's Code
        /// </summary>
		public virtual string Code {
			set{ this.code = value;}
			get{ return this.code;}
		}

		/// <summary>
        /// Gets the ActivatedPromotion's Promotion
        /// </summary>
		public abstract Promotion Promotion {get;set; }

		/// <summary>
        /// Gets the ActivatedPromotion's Principal
        /// </summary>
		public abstract Principal Principal {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ActivatedPromotion) );
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
			str = Used.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Used\" : \"{0}\", ", str);
			str = Code.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Code\" : \"{0}\", ", str);
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
			get { return "ActivatedPromotion"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ActivatedPromotion other = obj as ActivatedPromotion;
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
