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
	public abstract partial class BattleExtention : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string battleFinalStates;
		private string battleMovements;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the BattleExtention's BattleFinalStates
        /// </summary>
		public virtual string BattleFinalStates {
			set{ this.battleFinalStates = value;}
			get{ return this.battleFinalStates;}
		}

		/// <summary>
        /// Gets the BattleExtention's BattleMovements
        /// </summary>
		public virtual string BattleMovements {
			set{ this.battleMovements = value;}
			get{ return this.battleMovements;}
		}

		/// <summary>
        /// Gets the BattleExtention's Battle
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
			XmlSerializer serializer = new XmlSerializer( typeof(BattleExtention) );
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
			str = BattleFinalStates.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleFinalStates\" : \"{0}\", ", str);
			str = BattleMovements.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BattleMovements\" : \"{0}\", ", str);
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
			get { return "BattleExtention"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			BattleExtention other = obj as BattleExtention;
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
