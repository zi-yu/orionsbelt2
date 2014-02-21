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
	public abstract partial class GlobalStats : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string type;
		private int tick;
		private string text;
		private double number;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the GlobalStats's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the GlobalStats's Tick
        /// </summary>
		public virtual int Tick {
			set{ this.tick = value;}
			get{ return this.tick;}
		}

		/// <summary>
        /// Gets the GlobalStats's Text
        /// </summary>
		public virtual string Text {
			set{ this.text = value;}
			get{ return this.text;}
		}

		/// <summary>
        /// Gets the GlobalStats's Number
        /// </summary>
		public virtual double Number {
			set{ this.number = value;}
			get{ return this.number;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(GlobalStats) );
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
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Tick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Tick\" : \"{0}\", ", str);
			str = Text.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Text\" : \"{0}\", ", str);
			str = Number.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Number\" : \"{0}\", ", str);
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
			get { return "GlobalStats"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			GlobalStats other = obj as GlobalStats;
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
