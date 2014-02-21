using System;
using System.Collections.Generic;
using System.Web.UI;
using DesignPatterns.Attributes;
using OrionsBelt.WebComponents;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {
	[FactoryKey("Sms")]
	public class SmsControl : PaymentControlBase {

		#region Fields

		#endregion Fields

		#region Fields

		private static void FillSupportedCountries(Dictionary<string,string> supportedCountries) {
			supportedCountries["Australia"] = "au";
			supportedCountries["Austria"] = "at";
			supportedCountries["Belgium"] = "be";
			supportedCountries["BosniaHerzegovina"] = "ba";
			supportedCountries["Bulgaria"] = "bg";
			supportedCountries["Canada"] = "ca";
			supportedCountries["Croatia"] = "hr";
			supportedCountries["CzechRepublic"] = "cz";
			supportedCountries["Denmark"] = "dk";
			supportedCountries["Estonia"] = "ee";
			supportedCountries["Finland"] = "fi";
			supportedCountries["France"] = "fr";
			supportedCountries["Germany"] = "de";
			supportedCountries["Hungary"] = "hu";
			supportedCountries["Indonesia"] = "id";
			supportedCountries["Ireland"] = "ie";
			supportedCountries["Italy"] = "it";
			supportedCountries["Kazakhstan"] = "kz";
			supportedCountries["Latvia"] = "lv";
			supportedCountries["Lithuania"] = "lt";
			supportedCountries["Malaysia"] = "my";
			supportedCountries["Holland"] = "nl";
			supportedCountries["Norway"] = "no";
			supportedCountries["Poland"] = "pl";
			supportedCountries["Portugal"] = "pt";
			supportedCountries["Romania"] = "ro";
			supportedCountries["Russia"] = "ru";
			supportedCountries["Serbia"] = "rs";
			supportedCountries["Singapore"] = "sg";
			supportedCountries["Spain"] = "es";
			supportedCountries["Sweden"] = "se";
			supportedCountries["Switzerland"] = "ch";
			supportedCountries["Taiwan"] = "tw";
			supportedCountries["Thailand"] = "th";
			supportedCountries["Ukraine"] = "ua";
			supportedCountries["UnitedKingdom"] = "gb";
			supportedCountries["UnitedStates"] = "us";
		}

		private static Dictionary<string, string> GetSupportedCountries() {
			if( State.HasCache("SupportedSmsCountries") ) {
				return (Dictionary<string, string>) State.GetCache("SupportedSmsCountries");
			}
			
			Dictionary<string,string> supportedCountries = new Dictionary<string, string>();
			FillSupportedCountries(supportedCountries);

			State.SetCache("SupportedSmsCountries", supportedCountries);
			return supportedCountries;
		}

		private static void WriteCountrySelection(TextWriter writer) {
			Dictionary<string, string> supportedCountries = GetSupportedCountries();
			writer.Write("<div id='supportedCountries'><select id='languageChooser' class='styled'>");
			writer.Write("<option value=''>{0}</option>", LanguageManager.Instance.Get("ChooseCountryOption"));
			foreach (KeyValuePair<string, string> pair in supportedCountries) {
				writer.Write("<option value='{0}'>{1}</option>", pair.Value, LanguageManager.Instance.Get(pair.Key));
			}
			writer.Write("</select><br/>{0}</div>", LanguageManager.Instance.Get("NotListedCountry"));
		}

		#endregion Fields
		
		#region Control Events

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			MainForm master = (MainForm)State.Items["MainForm"];
			master.RenderFormTag = false;
		}

		protected override void Render(HtmlTextWriter writer) {
            WriteCountrySelection(content);
            
            content.Write("<div id='pricesContent'>{0}</div>", LanguageManager.Instance.Get("ChooseCountry"));

            base.Render(writer);
		}

		#endregion Control Events

		#region IFactory Members

		public override object create(object args) {
			return new SmsControl();
		}

		#endregion IFactory Members

		#region Constructor

		public SmsControl() {
			paymentMethod = "Sms";
		}

		#endregion Constructor


	}
}

