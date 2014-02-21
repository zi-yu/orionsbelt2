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
	public abstract partial class Promotion : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private DateTime beginDate = DateTime.Now;
		private DateTime endDate = DateTime.Now;
		private string revenueType;
		private double revenue;
		private string promotionType;
		private int rangeBegin;
		private int rangeEnd;
		private int promotionCode;
		private string bonusType;
		private int bonus;
		private string status;
		private string description;
		private int uses;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Promotion's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the Promotion's BeginDate
        /// </summary>
		public virtual DateTime BeginDate {
			set{ this.beginDate = value;}
			get{ return this.beginDate;}
		}

		/// <summary>
        /// Gets the Promotion's EndDate
        /// </summary>
		public virtual DateTime EndDate {
			set{ this.endDate = value;}
			get{ return this.endDate;}
		}

		/// <summary>
        /// Gets the Promotion's RevenueType
        /// </summary>
		public virtual string RevenueType {
			set{ this.revenueType = value;}
			get{ return this.revenueType;}
		}

		/// <summary>
        /// Gets the Promotion's Revenue
        /// </summary>
		public virtual double Revenue {
			set{ this.revenue = value;}
			get{ return this.revenue;}
		}

		/// <summary>
        /// Gets the Promotion's PromotionType
        /// </summary>
		public virtual string PromotionType {
			set{ this.promotionType = value;}
			get{ return this.promotionType;}
		}

		/// <summary>
        /// Gets the Promotion's RangeBegin
        /// </summary>
		public virtual int RangeBegin {
			set{ this.rangeBegin = value;}
			get{ return this.rangeBegin;}
		}

		/// <summary>
        /// Gets the Promotion's RangeEnd
        /// </summary>
		public virtual int RangeEnd {
			set{ this.rangeEnd = value;}
			get{ return this.rangeEnd;}
		}

		/// <summary>
        /// Gets the Promotion's PromotionCode
        /// </summary>
		public virtual int PromotionCode {
			set{ this.promotionCode = value;}
			get{ return this.promotionCode;}
		}

		/// <summary>
        /// Gets the Promotion's BonusType
        /// </summary>
		public virtual string BonusType {
			set{ this.bonusType = value;}
			get{ return this.bonusType;}
		}

		/// <summary>
        /// Gets the Promotion's Bonus
        /// </summary>
		public virtual int Bonus {
			set{ this.bonus = value;}
			get{ return this.bonus;}
		}

		/// <summary>
        /// Gets the Promotion's Status
        /// </summary>
		public virtual string Status {
			set{ this.status = value;}
			get{ return this.status;}
		}

		/// <summary>
        /// Gets the Promotion's Description
        /// </summary>
		public virtual string Description {
			set{ this.description = value;}
			get{ return this.description;}
		}

		/// <summary>
        /// Gets the Promotion's Uses
        /// </summary>
		public virtual int Uses {
			set{ this.uses = value;}
			get{ return this.uses;}
		}

		/// <summary>
        /// Gets the Promotion's Activations
        /// </summary>
		[XmlIgnore()]
		public abstract System.Collections.Generic.IList<ActivatedPromotion> Activations {get;set; }

		/// <summary>
        /// Gets the Promotion's Owner
        /// </summary>
		public abstract Principal Owner {get;set; }

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Promotion) );
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
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = BeginDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BeginDate\" : \"{0}\", ", str);
			str = EndDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"EndDate\" : \"{0}\", ", str);
			str = RevenueType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RevenueType\" : \"{0}\", ", str);
			str = Revenue.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Revenue\" : \"{0}\", ", str);
			str = PromotionType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PromotionType\" : \"{0}\", ", str);
			str = RangeBegin.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RangeBegin\" : \"{0}\", ", str);
			str = RangeEnd.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"RangeEnd\" : \"{0}\", ", str);
			str = PromotionCode.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"PromotionCode\" : \"{0}\", ", str);
			str = BonusType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BonusType\" : \"{0}\", ", str);
			str = Bonus.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Bonus\" : \"{0}\", ", str);
			str = Status.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Status\" : \"{0}\", ", str);
			str = Description.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Description\" : \"{0}\", ", str);
			str = Uses.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Uses\" : \"{0}\", ", str);
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
			get { return "Promotion"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Promotion other = obj as Promotion;
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
