using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.Generic.Messages {

	[NoAutoRegister]
	public abstract class DialogueMessage: MessageBase {

		#region Properties

		public override Category Category {
			get { return Category.Player; }
		}

        public override MessageImportance Importance {
            get { return MessageImportance.Dialogue; }
        }

        public abstract DialogueMessageType DialogueType { get;}

		#endregion Properties

        #region Localize

        public override string Translate()
        {
            if( parameters == null || parameters.Count == 0 ) {
                return base.Translate();
            }
            string sender = string.Format(LanguageTranslator.Translate("DialogueSender"), parameters[0], parameters[1]);
            return string.Format("{0}: {1}", sender, base.Translate());
        }

        #endregion Localize

        #region Create

        public override object create( object args ) {
			Message arguments = (Message) args;

			int ownerid = arguments.OwnerId;
			string[] s = arguments.Parameters.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			return CreateMessage(ownerid, s);
		}

		#endregion Create

		#region Abstract

		protected abstract IMessage CreateMessage(int ownerId, params object[] p);

		#endregion Abstract

		#region Constructor

		public DialogueMessage() {}

        public DialogueMessage(int ownerId, params object[] p)
        {
			date = DateTime.Now;
			this.ownerId = ownerId;
			
			foreach (object s in p) {
				parameters.Add(s.ToString());
			}
		}

		#endregion Constructor

	};

}
