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
	public abstract partial class Interaction : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int source;
		private int target;
		private string type;
		private bool response;
		private string responseExtension;
		private string interactionContext;
		private bool resolved;
		private string sourceAditionalData;
		private string targetAditionalData;
		private string sourceType;
		private string targetType;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the Interaction's Source
        /// </summary>
		public virtual int Source {
			set{ this.source = value;}
			get{ return this.source;}
		}

		/// <summary>
        /// Gets the Interaction's Target
        /// </summary>
		public virtual int Target {
			set{ this.target = value;}
			get{ return this.target;}
		}

		/// <summary>
        /// Gets the Interaction's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the Interaction's Response
        /// </summary>
		public virtual bool Response {
			set{ this.response = value;}
			get{ return this.response;}
		}

		/// <summary>
        /// Gets the Interaction's ResponseExtension
        /// </summary>
		public virtual string ResponseExtension {
			set{ this.responseExtension = value;}
			get{ return this.responseExtension;}
		}

		/// <summary>
        /// Gets the Interaction's InteractionContext
        /// </summary>
		public virtual string InteractionContext {
			set{ this.interactionContext = value;}
			get{ return this.interactionContext;}
		}

		/// <summary>
        /// Gets the Interaction's Resolved
        /// </summary>
		public virtual bool Resolved {
			set{ this.resolved = value;}
			get{ return this.resolved;}
		}

		/// <summary>
        /// Gets the Interaction's SourceAditionalData
        /// </summary>
		public virtual string SourceAditionalData {
			set{ this.sourceAditionalData = value;}
			get{ return this.sourceAditionalData;}
		}

		/// <summary>
        /// Gets the Interaction's TargetAditionalData
        /// </summary>
		public virtual string TargetAditionalData {
			set{ this.targetAditionalData = value;}
			get{ return this.targetAditionalData;}
		}

		/// <summary>
        /// Gets the Interaction's SourceType
        /// </summary>
		public virtual string SourceType {
			set{ this.sourceType = value;}
			get{ return this.sourceType;}
		}

		/// <summary>
        /// Gets the Interaction's TargetType
        /// </summary>
		public virtual string TargetType {
			set{ this.targetType = value;}
			get{ return this.targetType;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(Interaction) );
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
			str = Source.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Source\" : \"{0}\", ", str);
			str = Target.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Target\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = Response.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Response\" : \"{0}\", ", str);
			str = ResponseExtension.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"ResponseExtension\" : \"{0}\", ", str);
			str = InteractionContext.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"InteractionContext\" : \"{0}\", ", str);
			str = Resolved.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Resolved\" : \"{0}\", ", str);
			str = SourceAditionalData.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SourceAditionalData\" : \"{0}\", ", str);
			str = TargetAditionalData.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TargetAditionalData\" : \"{0}\", ", str);
			str = SourceType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"SourceType\" : \"{0}\", ", str);
			str = TargetType.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"TargetType\" : \"{0}\", ", str);
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
			get { return "Interaction"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			Interaction other = obj as Interaction;
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
