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
	public abstract partial class TimedActionStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int startTick;
		private int endTick;
		private string data;
		private string name;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the TimedActionStorage's StartTick
        /// </summary>
		public virtual int StartTick {
			set{ this.startTick = value;}
			get{ return this.startTick;}
		}

		/// <summary>
        /// Gets the TimedActionStorage's EndTick
        /// </summary>
		public virtual int EndTick {
			set{ this.endTick = value;}
			get{ return this.endTick;}
		}

		/// <summary>
        /// Gets the TimedActionStorage's Data
        /// </summary>
		public virtual string Data {
			set{ this.data = value;}
			get{ return this.data;}
		}

		/// <summary>
        /// Gets the TimedActionStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the TimedActionStorage's Player
        /// </summary>
		public abstract PlayerStorage Player {get;set; }

		/// <summary>
        /// Gets the TimedActionStorage's Battle
        /// </summary>
		public abstract Battle Battle {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(TimedActionStorage) );
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
			str = StartTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StartTick\" : \"{0}\", ", str);
			str = EndTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndTick\" : \"{0}\", ", str);
			str = Data.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Data\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
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
			get { return "TimedActionStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			TimedActionStorage other = obj as TimedActionStorage;
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
