using System;
using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class MessageBase: IMessage {

		#region Fields

		protected List<string> parameters = new List<string>();
		protected int ownerId;
		protected DateTime date;
		protected string log;
		protected string extended;
        protected int deadline = 0;
		protected IMessageParameterTranslator coordinateTranslator;
		protected IMessageParameterTranslator positionTranslator;
		protected IMessageParameterTranslator languageTranslator;
		protected static readonly char[] separator = new char[] { ';' };
        protected bool isNotifiable = false;

		#endregion Fields

		#region Properties

		public virtual MessageType MessageType {
			get { return MessageType.Generic; }
		}

		public string SubCategory {
			get { return GetType().Name; }
		}

        public virtual MessageImportance Importance {
            get { return MessageImportance.Normal; }
        }

		public virtual List<string> Parameters {
			get { return parameters; }
			set { parameters = value; }
		}

        public int TickDeadline {
            get { return deadline; }
            set { deadline = value; }
        }

		public virtual int OwnerId {
			get { return ownerId; }
			set { ownerId = value; }
		}

		public DateTime Date {
			get { return date; }
			set { date = value; }
		}

		public string Extended {
			get { return extended; }
			set { extended = value;}
		}

		/// <summary>
		/// Translates a coordinate
		/// </summary>
		public IMessageParameterTranslator CoordinateTranslator {
			get {
				return coordinateTranslator;
			}
			set {
				coordinateTranslator = value;
			}
		}

		/// <summary>
		/// Translates a coordinate
		/// </summary>
		public IMessageParameterTranslator PositionTranslator {
			get {
				return positionTranslator;
			}
			set {
				positionTranslator = value;
			}
		}

		/// <summary>
		/// Translates a I18n token
		/// </summary>
		public IMessageParameterTranslator LanguageTranslator {
			get {
				return languageTranslator;
			}
			set {
				languageTranslator = value;	
			} 
		}

        /// <summary>
		/// if this message can be 
		/// </summary>
		public virtual bool IsNotifiable {
            get { return isNotifiable; }
            set { isNotifiable = value; } 
		}

		#endregion Properties

		#region Public

		public string Log() {
			return string.Format( log, parameters );
		}

		/// <summary>
		/// Translates the message
		/// </summary>
		public virtual string Translate() {
			try{
				return string.Format(languageTranslator.Translate(SubCategory), Parameters.ToArray());
			}catch(FormatException) {
				throw new OrionsBeltException("Invalid format at Message '{0}'. Parameter count: {1}", SubCategory, Parameters.Count);
			}
		}

		#endregion

		#region Abstract

		public abstract Category Category { get; }
		public abstract object create( object args );
			
		#endregion Abstract

	}
}
