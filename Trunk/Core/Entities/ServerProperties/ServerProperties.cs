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
	public abstract partial class ServerProperties : OrionsBelt.Core.Entity, IDescriptable, IComparable  {

		#region Fields

		private int currentTick;
		private DateTime lastTickDate = DateTime.Now;
		private bool running;
		private int millisPerTick;
		private bool useWebClock;
		private int maxPlayers;
		private int vacationTicksPerWeek;
		private string name;
		private string baseUrl;
		#endregion Fields

		#region Properties

		/// <summary>
        /// Gets the ServerProperties's CurrentTick
        /// </summary>
		public virtual int CurrentTick {
			set{ this.currentTick = value;}
			get{ return this.currentTick;}
		}

		/// <summary>
        /// Gets the ServerProperties's LastTickDate
        /// </summary>
		public virtual DateTime LastTickDate {
			set{ this.lastTickDate = value;}
			get{ return this.lastTickDate;}
		}

		/// <summary>
        /// Gets the ServerProperties's Running
        /// </summary>
		public virtual bool Running {
			set{ this.running = value;}
			get{ return this.running;}
		}

		/// <summary>
        /// Gets the ServerProperties's MillisPerTick
        /// </summary>
		public virtual int MillisPerTick {
			set{ this.millisPerTick = value;}
			get{ return this.millisPerTick;}
		}

		/// <summary>
        /// Gets the ServerProperties's UseWebClock
        /// </summary>
		public virtual bool UseWebClock {
			set{ this.useWebClock = value;}
			get{ return this.useWebClock;}
		}

		/// <summary>
        /// Gets the ServerProperties's MaxPlayers
        /// </summary>
		public virtual int MaxPlayers {
			set{ this.maxPlayers = value;}
			get{ return this.maxPlayers;}
		}

		/// <summary>
        /// Gets the ServerProperties's VacationTicksPerWeek
        /// </summary>
		public virtual int VacationTicksPerWeek {
			set{ this.vacationTicksPerWeek = value;}
			get{ return this.vacationTicksPerWeek;}
		}

		/// <summary>
        /// Gets the ServerProperties's Name
        /// </summary>
		public virtual string Name {
			set{ this.name = value;}
			get{ return this.name;}
		}

		/// <summary>
        /// Gets the ServerProperties's BaseUrl
        /// </summary>
		public virtual string BaseUrl {
			set{ this.baseUrl = value;}
			get{ return this.baseUrl;}
		}

		#endregion Properties
		
		#region IDescriptable Implementation
		
		public virtual string ToHtml()
		{
			throw new NotImplementedException();
		}
		
		public virtual string ToXml()
		{
			XmlSerializer serializer = new XmlSerializer( typeof(ServerProperties) );
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
			str = CurrentTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"CurrentTick\" : \"{0}\", ", str);
			str = LastTickDate.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"LastTickDate\" : \"{0}\", ", str);
			str = Running.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Running\" : \"{0}\", ", str);
			str = MillisPerTick.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MillisPerTick\" : \"{0}\", ", str);
			str = UseWebClock.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"UseWebClock\" : \"{0}\", ", str);
			str = MaxPlayers.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"MaxPlayers\" : \"{0}\", ", str);
			str = VacationTicksPerWeek.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"VacationTicksPerWeek\" : \"{0}\", ", str);
			str = Name.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"Name\" : \"{0}\", ", str);
			str = BaseUrl.ToString();
			str = str.Replace('\"', '\'').Replace('\n', ' ');
			writer.Write("\"BaseUrl\" : \"{0}\", ", str);
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
			get { return "ServerProperties"; }
		}
		
		#endregion IDescriptable Implementation
		
		#region IComparable Implementation
		
		public virtual int CompareTo( object obj )
		{
			ServerProperties other = obj as ServerProperties;
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
