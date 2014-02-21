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
	public abstract partial class PlayerStats : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int numberOfPlayedBattles;
		private int numberPirateQuest;
		private int numberBountyQuests;
		private int numberMerchantQuests;
		private int numberGladiatorQuests;
		private int numberColonizerQuests;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the PlayerStats's NumberOfPlayedBattles
        /// </summary>
		public virtual int NumberOfPlayedBattles {
			set{ this.numberOfPlayedBattles = value;}
			get{ return this.numberOfPlayedBattles;}
		}

		/// <summary>
        /// Gets the PlayerStats's NumberPirateQuest
        /// </summary>
		public virtual int NumberPirateQuest {
			set{ this.numberPirateQuest = value;}
			get{ return this.numberPirateQuest;}
		}

		/// <summary>
        /// Gets the PlayerStats's NumberBountyQuests
        /// </summary>
		public virtual int NumberBountyQuests {
			set{ this.numberBountyQuests = value;}
			get{ return this.numberBountyQuests;}
		}

		/// <summary>
        /// Gets the PlayerStats's NumberMerchantQuests
        /// </summary>
		public virtual int NumberMerchantQuests {
			set{ this.numberMerchantQuests = value;}
			get{ return this.numberMerchantQuests;}
		}

		/// <summary>
        /// Gets the PlayerStats's NumberGladiatorQuests
        /// </summary>
		public virtual int NumberGladiatorQuests {
			set{ this.numberGladiatorQuests = value;}
			get{ return this.numberGladiatorQuests;}
		}

		/// <summary>
        /// Gets the PlayerStats's NumberColonizerQuests
        /// </summary>
		public virtual int NumberColonizerQuests {
			set{ this.numberColonizerQuests = value;}
			get{ return this.numberColonizerQuests;}
		}

		/// <summary>
        /// Gets the PlayerStats's Player
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<PlayerStorage> Player {get;set; }

		/// <summary>
        /// Gets the PlayerStats's BattleStats
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<BattleStats> BattleStats {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(PlayerStats) );
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
			str = NumberOfPlayedBattles.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberOfPlayedBattles\" : \"{0}\", ", str);
			str = NumberPirateQuest.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberPirateQuest\" : \"{0}\", ", str);
			str = NumberBountyQuests.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberBountyQuests\" : \"{0}\", ", str);
			str = NumberMerchantQuests.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberMerchantQuests\" : \"{0}\", ", str);
			str = NumberGladiatorQuests.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberGladiatorQuests\" : \"{0}\", ", str);
			str = NumberColonizerQuests.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"NumberColonizerQuests\" : \"{0}\", ", str);
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
			get { return "PlayerStats"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			PlayerStats other = obj as PlayerStats;
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
