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
	public abstract partial class VoteReferral : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private string name;
		private string shortName;
		private string url;
		private string imageUrl;
		private string reward;
		private int clickCount;
		private int voteOrder;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the VoteReferral's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the VoteReferral's ShortName
        /// </summary>
		public virtual string ShortName {
			set{ this.shortName = value;}
			get{ return this.shortName;}
		}

		/// <summary>
        /// Gets the VoteReferral's Url
        /// </summary>
		public virtual string Url {
			set{ this.url = value;}
			get{ return this.url;}
		}

		/// <summary>
        /// Gets the VoteReferral's ImageUrl
        /// </summary>
		public virtual string ImageUrl {
			set{ this.imageUrl = value;}
			get{ return this.imageUrl;}
		}

		/// <summary>
        /// Gets the VoteReferral's Reward
        /// </summary>
		public virtual string Reward {
			set{ this.reward = value;}
			get{ return this.reward;}
		}

		/// <summary>
        /// Gets the VoteReferral's ClickCount
        /// </summary>
		public virtual int ClickCount {
			set{ this.clickCount = value;}
			get{ return this.clickCount;}
		}

		/// <summary>
        /// Gets the VoteReferral's VoteOrder
        /// </summary>
		public virtual int VoteOrder {
			set{ this.voteOrder = value;}
			get{ return this.voteOrder;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(VoteReferral) );
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
			str = ShortName.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ShortName\" : \"{0}\", ", str);
			str = Url.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Url\" : \"{0}\", ", str);
			str = ImageUrl.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ImageUrl\" : \"{0}\", ", str);
			str = Reward.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Reward\" : \"{0}\", ", str);
			str = ClickCount.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ClickCount\" : \"{0}\", ", str);
			str = VoteOrder.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VoteOrder\" : \"{0}\", ", str);
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
			get { return "VoteReferral"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			VoteReferral other = obj as VoteReferral;
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
