using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Exceptions;

namespace OrionsBelt.WebUserInterface.Ajax {

	/// <summary>
	/// Summary description for Positioning
	/// </summary>
	public abstract class BaseHandler : IHttpHandler, IRequiresSessionState {

		#region Fields

		protected HttpContext context;
		protected LogType type = LogType.Generic;
		protected StringWriter writer = new StringWriter();
		protected StringWriter errorWriter = new StringWriter();

		#endregion Fields

		#region Private



		#endregion Private

		#region Protected

		protected virtual void WriteContent( IBattleInfo battleInfo, IBattleOwner battleOwner ){}

		protected void WriteParameterError() {
			context.Response.Write("Parameter error");
		}

		protected void WriteError( Result result ) {
			StringBuilder builder = new StringBuilder();
			foreach( ResultItem item in result.Failed ) {
				builder.AppendFormat("{0}<br/>", item.Log());
			}
			context.Response.Write(builder.ToString());
		}

		protected static void WriteIsNotTurnError( HttpContext context ) {
			context.Response.Write(LanguageManager.Instance.Get("IsNotYourTurn"));
		}

		protected int GetId() {
			return GetIntParameter("id");
		}

		protected int GetIntParameter(string key) {
			string strid = context.Request.QueryString[key];
			int id;
			if (!int.TryParse(strid, out id)) {
				throw new BattleExceptionUI(LanguageManager.Instance.Get("InvalidBattleId"));
			}
			return id;
		}

		protected Coordinate ParseCoordinate(string coord) {
			try {
				return new Coordinate(coord);
			} catch (RulesException) {
				Logger.Error(HttpContext.Current.User.Identity.Name, type, "Invalid Coordinate", coord);
				throw new UIException("Invalid Coordinate {0} ", coord);
			}
		}

		protected void WriteHtml() {
			HttpContext.Current.Response.Write(errorWriter.ToString());
			HttpContext.Current.Response.Write(writer.ToString());
		}

		protected void WriteError(string error) {
			errorWriter.Write(error);
		}

		#endregion Protected

		#region IHttpHandler Members

		public virtual bool IsReusable {
			get { return false; }
		}

		public virtual void ProcessRequest( HttpContext c ) {
			context = c;
			Init();
		}

		public virtual void Init() {}

		#endregion
	}
}
