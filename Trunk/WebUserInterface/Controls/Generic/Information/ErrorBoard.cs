using System.IO;
using System.Web;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {

	public class ErrorBoard : MessageBoard {

		#region Fields

		private static readonly string imageS = "Error.gif";
		private static readonly string keyS = "ErrorBoard";

		#endregion Fields

		#region Static

		protected static MessageBoard GetMessageBoard() {
			if (!State.HasItems(keyS)) {
                State.SetItems(keyS,new ErrorBoard());
			}
			return (MessageBoard)State.GetItems(keyS);
		}

		#endregion Static

		#region Static

		public static void AddMessage( string message ) {
			MessageBoard info = GetMessageBoard();
			info.InsertMessage(message);
		}

		public static void AddLocalizedMessage( string key ) {
			MessageBoard info = GetMessageBoard();
			info.InsertLocalizedMessage(key);
		}

		public static void AddLocalizedMessage( string key, params string[] parameters ) {
			MessageBoard info = GetMessageBoard();
			info.InsertLocalizedMessage(key, parameters);
		}

		public new static void GetBoardHtml(TextWriter writer) {
			MessageBoard info = GetMessageBoard();
			info.GetBoardHtml(writer);
		}

		#endregion

		#region Events

		protected override void OnInit(System.EventArgs e) {
			SearchSimilarControls<ErrorBoard>(keyS, Parent.Controls);
		}

		#endregion Events

		#region Construtor

		public ErrorBoard() {
            Title = LanguageManager.Instance.Get("Errors");
			image = imageS;
		}
		
		#endregion Constructor
	}
}
