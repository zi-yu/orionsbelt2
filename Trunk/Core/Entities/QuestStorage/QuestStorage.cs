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
	public abstract partial class QuestStorage : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private double percentage;
		private bool isTemplate;
		private string name;
		private string type;
		private int deadlineTick;
		private int startTick;
		private string reward;
		private string questStringConfig;
		private string questIntConfig;
		private string questIntProgress;
		private string questStringProgress;
		private bool completed;
		private bool isProgressive;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the QuestStorage's Percentage
        /// </summary>
		public virtual double Percentage {
			set{ this.percentage = value;}
			get{ return this.percentage;}
		}

		/// <summary>
        /// Gets the QuestStorage's IsTemplate
        /// </summary>
		public virtual bool IsTemplate {
			set{ this.isTemplate = value;}
			get{ return this.isTemplate;}
		}

		/// <summary>
        /// Gets the QuestStorage's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the QuestStorage's Type
        /// </summary>
		public virtual string Type {
			set{ this.type = value;}
			get{ return this.type;}
		}

		/// <summary>
        /// Gets the QuestStorage's DeadlineTick
        /// </summary>
		public virtual int DeadlineTick {
			set{ this.deadlineTick = value;}
			get{ return this.deadlineTick;}
		}

		/// <summary>
        /// Gets the QuestStorage's StartTick
        /// </summary>
		public virtual int StartTick {
			set{ this.startTick = value;}
			get{ return this.startTick;}
		}

		/// <summary>
        /// Gets the QuestStorage's Reward
        /// </summary>
		public virtual string Reward {
			set{ this.reward = value;}
			get{ return this.reward;}
		}

		/// <summary>
        /// Gets the QuestStorage's QuestStringConfig
        /// </summary>
		public virtual string QuestStringConfig {
			set{ this.questStringConfig = value;}
			get{ return this.questStringConfig;}
		}

		/// <summary>
        /// Gets the QuestStorage's QuestIntConfig
        /// </summary>
		public virtual string QuestIntConfig {
			set{ this.questIntConfig = value;}
			get{ return this.questIntConfig;}
		}

		/// <summary>
        /// Gets the QuestStorage's QuestIntProgress
        /// </summary>
		public virtual string QuestIntProgress {
			set{ this.questIntProgress = value;}
			get{ return this.questIntProgress;}
		}

		/// <summary>
        /// Gets the QuestStorage's QuestStringProgress
        /// </summary>
		public virtual string QuestStringProgress {
			set{ this.questStringProgress = value;}
			get{ return this.questStringProgress;}
		}

		/// <summary>
        /// Gets the QuestStorage's Completed
        /// </summary>
		public virtual bool Completed {
			set{ this.completed = value;}
			get{ return this.completed;}
		}

		/// <summary>
        /// Gets the QuestStorage's IsProgressive
        /// </summary>
		public virtual bool IsProgressive {
			set{ this.isProgressive = value;}
			get{ return this.isProgressive;}
		}

		/// <summary>
        /// Gets the QuestStorage's Player
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
			XmlSerializer serializer = new XmlSerializer( typeof(QuestStorage) );
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
			str = Percentage.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Percentage\" : \"{0}\", ", str);
			str = IsTemplate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsTemplate\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = Type.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Type\" : \"{0}\", ", str);
			str = DeadlineTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"DeadlineTick\" : \"{0}\", ", str);
			str = StartTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"StartTick\" : \"{0}\", ", str);
			str = Reward.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Reward\" : \"{0}\", ", str);
			str = QuestStringConfig.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QuestStringConfig\" : \"{0}\", ", str);
			str = QuestIntConfig.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QuestIntConfig\" : \"{0}\", ", str);
			str = QuestIntProgress.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QuestIntProgress\" : \"{0}\", ", str);
			str = QuestStringProgress.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"QuestStringProgress\" : \"{0}\", ", str);
			str = Completed.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Completed\" : \"{0}\", ", str);
			str = IsProgressive.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"IsProgressive\" : \"{0}\", ", str);
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
			get { return "QuestStorage"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			QuestStorage other = obj as QuestStorage;
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
