using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine {
	public static class Generals {

		#region Fields


		#endregion Fields

		#region Properties

		public static List<Principal> List {
			get { return (List<Principal>)State.GetCache("Generals"); }
		}

		public static Principal OneStarGeneral {
			get { return GetGeneralByName("Bot001"); }
		}

		public static Principal FiringSquadGeneral {
			get { return GetGeneralByName("FiringSquad"); }
		}

		#endregion Properties

		#region Public

		public static Principal GetGeneralByName(string name) {
			return List.Find(delegate(Principal p) { return p.Name == name; });
		}

		public static Principal GetGeneralById(int id) {
			return List.Find(delegate(Principal p) { return p.Id == id; });
		}

		#endregion Public

		#region Constructor

		static Generals() {
			if (!State.HasCache("Generals")) {
				List<Principal> generals = (List<Principal>)Hql.StatelessQuery<Principal>("select p from SpecializedPrincipal p where p.IsBot = 1 and p.BotUrl<>'' and p.Name <> 'Metallic Beard' and p.Name <> 'Commander Wolf'");
				State.SetCache("Generals", generals);
			}
		}

		#endregion Constructor
	}

}
