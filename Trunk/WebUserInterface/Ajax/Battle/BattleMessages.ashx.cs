using System.Web;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Exceptions;

namespace OrionsBelt.WebUserInterface.Ajax {

	/// <summary>
	/// Summary description for Positioning
	/// </summary>
	public class BattleMessages: BaseHandler {

		#region Private
		
		protected void WriteMessageError() {
			context.Response.Write("Message Error");
		}

		private void WriteAllMessages( int id ) {
			IBattleInfo battleInfo = BattleUtilities.GetBattle(id);
			IBattleOwner battleOwner = BattleUtilities.GetCurrentOwner(battleInfo);
			WebBattle.BattleMessages bm = new WebBattle.BattleMessages(battleInfo, battleOwner, true);
			context.Response.Write(bm.Render());
		}

		private string GetOptions() {
			string options = context.Request.QueryString["options"];
			if( string.IsNullOrEmpty(options) ) {
				return string.Empty;
			}
			return options;
		}

		#endregion

		#region IHttpHandler Implementation

		public override void Init() {
			type = LogType.Battle;
		}

		public override void ProcessRequest(HttpContext c) {
			base.ProcessRequest(c);
			
			try {
				int id = GetId();
				string options = GetOptions();
			
				if( options.Length == 0 ) {
					WriteAllMessages(id);				
				}
			} catch( BattleExceptionUI ) {
				WriteMessageError();
			}
		}

		#endregion IHttpHandler Implementation
	}
}
