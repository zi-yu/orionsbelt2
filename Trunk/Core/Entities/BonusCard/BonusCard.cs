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
	public abstract partial class BonusCard : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string type;
		private string code;
		private int orions;
		private bool used;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the BonusCard's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the BonusCard's Code
        /// </summary>
		public virtual string Code {
			set{ this.code = value;}
			get{ return this.code;}
		}

		/// <summary>
        /// Gets the BonusCard's Orions
        /// </summary>
		public virtual int Orions {
			set{ this.orions = value;}
			get{ return this.orions;}
		}

		/// <summary>
        /// Gets the BonusCard's Used
        /// </summary>
		public virtual bool Used {
			set{ this.used = value;}
			get{ return this.used;}
		}

		/// <summary>
        /// Gets the BonusCard's UsedBy
        /// </summary>
		public abstract Principal UsedBy {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(BonusCard) );
			using( TextWriter writer = new StringWriter() ) {
				serializer.Serialize( writer, this );
				return writer.ToString();
			}
		}
		
		public virtual string ToLog()
		{
			return string.Format("[{0}:{1}] {2}", TypeName, Id, Type);
		}
		
		public virtual string ToJson()
		{
			StringWriter writer = new StringWriter();
			writer.Write("{ ");
			string str = null;
			str = Id.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Id\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Code.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Code\" : \"{0}\", ", str);
			str = Orions.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Orions\" : \"{0}\", ", str);
			str = Used.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Used\" : \"{0}\", ", str);
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
			get { return "BonusCard"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			BonusCard other = obj as BonusCard;
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
			if( Type == null ) {
				return string.Empty;
			}
			return Type.ToString();
		}
		
		#endregion Overrided Members
		
	};
}
