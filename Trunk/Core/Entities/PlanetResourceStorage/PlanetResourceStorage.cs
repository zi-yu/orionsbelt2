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
	public abstract partial class PlanetResourceStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int quantity;
		private string state;
		private int level;
		private string type;
		private int queueOrder;
		private string slot;
		private int endTick;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlanetResourceStorage's Quantity
        /// </summary>
		public virtual int Quantity {
			set{ this.quantity = value;}
			get{ return this.quantity;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's State
        /// </summary>
		public virtual string State {
			set{ this.state = value;}
			get{ return this.state;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's Level
        /// </summary>
		public virtual int Level {
			set{ this.level = value;}
			get{ return this.level;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's QueueOrder
        /// </summary>
		public virtual int QueueOrder {
			set{ this.queueOrder = value;}
			get{ return this.queueOrder;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's Slot
        /// </summary>
		public virtual string Slot {
			set{ this.slot = value;}
			get{ return this.slot;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's EndTick
        /// </summary>
		public virtual int EndTick {
			set{ this.endTick = value;}
			get{ return this.endTick;}
		}

		/// <summary>
        /// Gets the PlanetResourceStorage's Planet
        /// </summary>
		public abstract PlanetStorage Planet {get;set; }

		/// <summary>
        /// Gets the PlanetResourceStorage's Player
        /// </summary>
		public abstract PlayerStorage Player {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PlanetResourceStorage) );
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
			str = Quantity.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Quantity\" : \"{0}\", ", str);
			str = State.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"State\" : \"{0}\", ", str);
			str = Level.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Level\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = QueueOrder.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QueueOrder\" : \"{0}\", ", str);
			str = Slot.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Slot\" : \"{0}\", ", str);
			str = EndTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndTick\" : \"{0}\", ", str);
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
			get { return "PlanetResourceStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlanetResourceStorage other = obj as PlanetResourceStorage;
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
