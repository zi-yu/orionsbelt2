using System.IO;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {

	public class InformationBoard : MessageBoard {

		#region Fields

		private static readonly string imageS = "Information.gif";
		private static readonly string keyS = "InformationBoard";

		#endregion Fields

		#region Static

		protected static MessageBoard GetMessageBoard() {
			if (!State.HasItems(keyS)) {
				return new InformationBoard();
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
			SearchSimilarControls<InformationBoard>(keyS, Parent.Controls);
		}

		#endregion Events

		#region Construtor

		public InformationBoard() {
            isInfo = true;
            Title = LanguageManager.Instance.Get("Information");
			image = imageS;
		}
		
		#endregion Constructor
	}
}
