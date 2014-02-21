using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {
	public static class PaymentDescriptionLoader {

		#region Private

		private static Dictionary<string, List<PaymentDescription>> GetPaymentDescriptions() {
			if (!State.HasCache("PaymentDescriptions")) {
				Load();
			}

			return (Dictionary<string, List<PaymentDescription>>)State.GetCache("PaymentDescriptions");
		}

		private static IList<PaymentDescription> GetPaymenTypes() {
			return Hql.Query<PaymentDescription>("select p from SpecializedPaymentDescription p");
		}

		private static void Load() {
			IList<PaymentDescription> paymentDescription = GetPaymenTypes();
			Dictionary<string, List<PaymentDescription>> descriptions = new Dictionary<string, List<PaymentDescription>>();
			foreach (PaymentDescription description in paymentDescription) {
				if (!descriptions.ContainsKey(description.Type)) {
					descriptions.Add(description.Type, new List<PaymentDescription>());
				}
				descriptions[description.Type].Add(description);
			}
			State.SetCache("PaymentDescriptions", descriptions);
		}

		#endregion Private

		#region Public

		public static List<PaymentDescription> GetPaymentDescriptions(string type) {
			Dictionary<string, List<PaymentDescription>> descriptions = GetPaymentDescriptions();
			if( descriptions.ContainsKey(type)) {
				return descriptions[type];
			}
			return new List<PaymentDescription>();
		}

		#endregion Public

	}
}

