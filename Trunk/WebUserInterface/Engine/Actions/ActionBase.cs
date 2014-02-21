using System.Collections.Generic;
using System.IO;
using System.Web;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Engine {
	public abstract class ActionBase {

		#region Fields

		protected delegate void Action();
		protected static Dictionary<string, Action> actions = new Dictionary<string, Action>();

		#endregion Fields

		#region Private

		protected virtual void WriteResult(Result result) {
			StringWriter writer = new StringWriter();

			if(result.Ok){
				foreach (ResultItem item in result.Passed) {
					SuccessBoard.AddLocalizedMessage(item.Name);
				}
				SuccessBoard.GetBoardHtml(writer);
			}else {
				foreach (ResultItem item in result.Failed) {
					ErrorBoard.AddLocalizedMessage(item.Name);
				}
				ErrorBoard.GetBoardHtml(writer);
			}
            HttpContext.Current.Response.Write(writer.ToString());
		}

		protected int ConvertToInt(string id) {
            string strId = HttpContext.Current.Request.QueryString[id];
			int i;
			if (int.TryParse(strId, out i)) {
				return i;
			}
			return -1;
		}

		protected static Coordinate ParseCoordinate(string coord) {
			try {
				return new Coordinate(coord);
			} catch (RulesException) {
				Logger.Error(HttpContext.Current.User.Identity.Name, LogType.FleetMovement, "Invalid Coordinate", coord);
				throw new UIException("Invalid Coordinate {0} ", coord);
			}
		}

		#endregion Private

		#region Public

		public void ProcessActions(string type) {
			if (actions.ContainsKey(type)) {
				actions[type]();
			}
		}

		#endregion Public

	}
}
