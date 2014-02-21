using System.Collections.Generic;
using System.IO;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class SearchPlayer: IHttpHandler {

		#region Fields

		private delegate void GetElements(HttpContext context);
		private static readonly Dictionary<string, GetElements> elements = new Dictionary<string, GetElements>();

		#endregion Fields

		#region Delegates

		private static void GetPrincipals(HttpContext context) {
			string name = context.Request.QueryString["name"];
			IList<Principal> principals = GetPrincipals(name);
			WritePrincipals(principals, context);
		}

		private static void GetPlayers(HttpContext context) {
			string name = context.Request.QueryString["name"];
			IList<PlayerStorage> players = GetPlayers(name);
			WritePlayers(players, context);
		}

		#endregion Delegates

		#region Principals

		private static IList<Principal> GetPrincipals( string name ) {
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ){
				return persistance.TypedQuery("select p from SpecializedPrincipal p where p.Name like '%{0}%'", name);
			}
		}

		private static void WritePrincipals( IList<Principal> principals, HttpContext context ) {
			StringWriter writer = new StringWriter();
			writer.Write("<select id='opponent' class='styled'>");
			foreach (Principal principal in principals) {
				writer.Write("<option value='{0}'>{1}</option>",principal.Id,principal.DisplayName);
			}
			writer.Write("</select>");

			context.Response.Write(writer.ToString());
		}

		#endregion Principals

		#region Players

		private static IList<PlayerStorage> GetPlayers(string name) {
			using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
				return persistance.TypedQuery("select p from SpecializedPlayerStorage p where p.Name like '%{0}%'", name);
			}
		}

		private static void WritePlayers(IList<PlayerStorage> players, HttpContext context) {
			StringWriter writer = new StringWriter();
			writer.Write("<select id='opponent' class='styled'>");
			foreach (PlayerStorage player in players) {
				writer.Write("<option value='{0}'>{1}</option>", player.Id, player.Name);
			}

			writer.Write("</select>");

			context.Response.Write(writer.ToString());
		}

		#endregion Players

		#region IHttpHandler Implementation

		public void ProcessRequest( HttpContext context ) {
			string type = context.Request.QueryString["type"];
			if(elements.ContainsKey(type)) {
				elements[type](context);
			}
		}

		public bool IsReusable {
			get {
				return true;
			}
		}

		#endregion IHttpHandler Implementation

		#region Constructor

		static SearchPlayer() {
			elements["principal"] = GetPrincipals;
			elements["player"] = GetPlayers;
		}

		#endregion Constructor
	}
}
