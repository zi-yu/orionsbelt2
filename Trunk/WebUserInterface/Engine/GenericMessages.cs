using System.Collections.Generic;
using System.IO;
using System.Text;
using OrionsBelt.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using System;

namespace OrionsBelt.WebUserInterface.Engine {

	public class GenericMessages {

		#region Fields

        private readonly int ownerId = 0;
		private readonly bool allMessages = false;
		private readonly Category category;
        private readonly IList<Message> messages = null;

		#endregion Fields

        #region Properties

        private string css;

        public string Css
        {
            get { return css; }
            set { css = value; }
        }

        private bool includeImages = true;

        public bool IncludeImages
        {
            get { return includeImages; }
            set { includeImages = value; }
        }

        private bool includeElapsedTime = false;

        public bool IncludeElapsedTime
        {
            get { return includeElapsedTime; }
            set { includeElapsedTime = value; }
        }

        private bool includeEmptyMessage = true;

        public bool IncludeEmptyMessage
        {
            get { return includeEmptyMessage; }
            set { includeEmptyMessage = value; }
        }

        #endregion Properties

        #region Private

		/// <summary>
		/// Gets the messages for the current battle
		/// </summary>
		/// <returns></returns>
		private List<IMessage> GetMessages() {
            if (messages != null) {
                return Messenger.ConvertMessages(messages);
            }
            if (ownerId == 0) {
                return Messenger.GetMessagesByCategory(this.category);
            }
			if( allMessages ) {
				return Messenger.GetAllMessages(category, ownerId);
			}
			return Messenger.GetMessages(category, ownerId);
		}

		private void WriteMessages(TextWriter writer) {
			List<IMessage> messages = GetMessages();
            if (messages == null || messages.Count == 0) {
                if (IncludeEmptyMessage) {
                    writer.Write("<tr class='message'><td>{0}</td></tr>", LanguageManager.Instance.Get("NoMessages"));
                }
                return;
            }
			for( int i = 0; i < messages.Count; ++i ) {
				WriteMessage(writer,messages[i],i);
			}
		}
		
		private static string ConvertMessage(IMessage message) {
			message.LanguageTranslator = LanguageParameterTranslator.Instance;
			return message.Translate();
		}

		private void WriteMessage( TextWriter writer, IMessage message, int position ) {
            string timeAgoStr = LanguageManager.Instance.Get("TimeAgo");
			writer.Write("<tr class='message' id='msg{0}'>", position);
            if (IncludeImages) {
                writer.Write("<td class='msgImg'><img src='{0}' alt='{1}' title='{1}' /></td>", ResourcesManager.GetMessageImage(message), message.SubCategory);
            }
			writer.Write("<td class='{1}Message'>{0}</td>", ConvertMessage(message), message.Importance );
            if (IncludeElapsedTime) {
                writer.Write("<td>{0}</td>", string.Format(timeAgoStr, TimeFormatter.GetFormattedTime(DateTime.Now - message.Date)));
            }
			writer.Write("</tr>");
		}

        private string GetCss()
        {
            if (string.IsNullOrEmpty(Css)) {
                return string.Empty;
            }
            return string.Format(" class='{0}'", Css);
        }

		#endregion Private

		#region Public

		public string Render() {
			StringBuilder builder = new StringBuilder();
			StringWriter writer = new StringWriter(builder);
			Render(writer);
			return writer.ToString();
		}

		public void Render( TextWriter writer ) {
			writer.Write("<div id='genericMessages'><table{0}><tbody>", GetCss());
            WriteMessages(writer);
			writer.Write("</tbody></table></div>");
		}

		#endregion Public

		#region Constructor

        public GenericMessages(IList<Message> messages) {
            this.messages = messages;
        }

        public GenericMessages(Category category){
            this.category = category;
        }

        public GenericMessages(Category category, IAlliance alliance) {
			this.category = category;
            this.ownerId = alliance.Storage.Id;
		}

        public GenericMessages(Category category, IAlliance alliance, bool allMessages)
			: this(category, alliance) {
			this.allMessages = allMessages;
		}

        public GenericMessages(Category category, IPlayer player) {
			this.category = category;
            this.ownerId = player.Id;
		}

        public GenericMessages(IPlayer player)
        {
            this.ownerId = player.Id;
            this.category = Category.Player;
        }

		public GenericMessages(Category category, IPlayer player, bool allMessages)
			: this(category, player) {
			this.allMessages = allMessages;
		}

		public GenericMessages(Category category, int owner) {
			this.category = category;
            this.ownerId = owner;
		}

		public GenericMessages(Category category, int owner, bool allMessages)
			: this(category, owner) {
			this.allMessages = allMessages;
		}

		#endregion Constructor

	}
}
