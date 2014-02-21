using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {

	public class SuccessBoard : MessageBoard {

		#region Fields
		
		private static readonly string imageS = "Success.gif";
		private static readonly string keyS = "SuccessBoard";

		#endregion Fields

		#region Static

		protected static MessageBoard GetMessageBoard() {
			if( !State.HasItems(keyS)) {
				return new SuccessBoard();
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

		protected override void OnLoad(System.EventArgs e) {
			SearchSimilarControls<SuccessBoard>(keyS,Parent.Controls);
		}

		#endregion Events

		#region Construtor

		public SuccessBoard() {
            isInfo = true;
            Title = LanguageManager.Localize("Success");
			image = imageS;
			State.SetItems(keyS,this);
		}
		
		#endregion Constructor
	}
}
