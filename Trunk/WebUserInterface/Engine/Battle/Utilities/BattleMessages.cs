using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.Generic.Log;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleMessages  {

		#region Fields

		private readonly IBattlePlayer battlePlayer;
		private readonly bool hasEnded;
		private static readonly string path = "Messages/Battle";
		private readonly bool allMessages = false;

		private IMessageParameterTranslator positionTranslator;
		private IMessageParameterTranslator coordinateTranslator;
		
		#endregion Fields

		#region Private

		private static string CombinePath( string category ) {
			return string.Format("{0}/{1}", path,category);
		}

		/// <summary>
		/// Checks if the string is a position
		/// </summary>
		/// <param name="msg">String to verify</param>
		/// <returns>True of the parameter msg is a position</returns>
		private static bool IsPosition( string msg ) {
			char m = msg[0];
			return msg.Length == 1 && char.IsLetter(m) && char.IsUpper(m);
		}
		
		/// <summary>
		/// Convests the message to the specific player
		/// </summary>
		/// <param name="message">Message to translate</param>
		/// <returns></returns>
		private string ConvertMessage( IMessage message ) {
			if (battlePlayer.PlayerNumber == 0) {
				return string.Format(LanguageManager.Instance.Get(message.SubCategory), message.Parameters.ToArray());
			}

			//List<string> messageTranslated = new List<string>();
			//foreach (string msg in message.Parameters) {
			//    if (msg.IndexOf(separator) != -1) {
			//        string c = battlePlayer.PositionConverter.ConvertCoordinateToSpecific(msg);
			//        messageTranslated.Add(c);
			//        continue;
			//    }

			//    if (IsPosition(msg)) {
			//        messageTranslated.Add(battlePlayer.PositionConverter.ConvertPositionToSpecific(msg));
			//        continue;
			//    }

			//    messageTranslated.Add(msg);
			//}

			//return string.Format(LanguageManager.Instance.Get(message.SubCategory), messageTranslated.ToArray());
			message.CoordinateTranslator = coordinateTranslator;
			message.PositionTranslator = positionTranslator;
			message.LanguageTranslator = LanguageParameterTranslator.Instance;
			return message.Translate();
		}

		/// <summary>
		/// Gets the messages for the current battle
		/// </summary>
		/// <returns></returns>
		private List<IMessage> GetMessages() {
			string idStr = HttpContext.Current.Request.QueryString["id"];
			int id;
			if( int.TryParse(idStr, out id) ) {
				if( allMessages ) {
					return GetAllMessages(id);
				}
				return GetMessages(id);
			}

			string name;
			if(Utils.PrincipalExists) {
				name = Utils.Principal.DisplayName;
			}else {
				name = "Unknown";
			}
			Logger.Error(name,LogType.Battle, "Invalid Battle id: " + idStr);
			return null;
		}

		/// <summary>
		/// Gets the messages for the current battle
		/// </summary>
		/// <returns></returns>
		private List<IMessage> GetMessages( int id ) {
			if( hasEnded ) {
			    BattleUtilities.GetBattleMessagesInverted(id);
			}
            return BattleUtilities.GetBattleMessages(id);
		}

		/// <summary>
		/// Gets the messages for the current battle
		/// </summary>
		/// <returns></returns>
		private List<IMessage> GetAllMessages( int id ) {
			if( hasEnded ) {
				BattleUtilities.GetBattleMessagesInverted(id);
			}
			return BattleUtilities.GetAllBattleMessages(id);
		}

		private void WriteMessages(TextWriter writer) {
			List<IMessage> messages = GetMessages();
			if( messages != null ) {
				for( int i = 0; i < messages.Count; ++i ) {
					WriteMessage(writer,messages[i],i);
				}
			}
		}
		private static string GetImage(IMessage message) {
			return ResourcesManager.GetImage(CombinePath(message.SubCategory)) + ".gif";
		}

		private void WriteMessage( TextWriter writer, IMessage message, int position ) {
			writer.Write("<tr id='msg{0}'>", position);
			writer.Write("<td><img src='{0}' alt='{1}' title='{1}' /></td>", GetImage(message), message.SubCategory);
			writer.Write("<td>{0}</td>", ConvertMessage(message) );
			writer.Write("<td>{0}</td>",message.Extended);
			writer.Write("</tr>");
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
			writer.Write("<div id='battleMessages'><table><tbody>");
			WriteMessages(writer);
			writer.Write("</tbody></table></div>");
			
			writer.Write("<div><a href='javascript:Battle.getAllMessages()'>Get All</a></div>");
		}

		#endregion Public

		#region Constructor

		public BattleMessages( IBattleInfo battleInfo, IBattleOwner battleOwner) {
			battlePlayer = battleInfo.GetPlayer(battleOwner);
			hasEnded = battleInfo.HasEnded();

			positionTranslator = new PositionParameterTranslator(battlePlayer);
			coordinateTranslator = new CoordinateParameterTranslator(battlePlayer);
		}

		public BattleMessages( IBattleInfo battleInfo, IBattleOwner battleOwner, bool allMessages ) : this(battleInfo, battleOwner) {
			this.allMessages = allMessages;
		}

		#endregion Constructor

	}
}
