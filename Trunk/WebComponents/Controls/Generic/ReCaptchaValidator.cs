
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebComponents.Controls {
	public class ReCaptchaValidator : BaseValidator {

		#region Fields

		private string errorMessageKey = string.Empty;
		protected TextBox dummy = new TextBox();

		#endregion Fields

		#region Properties

		private static string PublicKey {
			get { return ConfigurationManager.AppSettings["publicKey"]; }
		}

		private static string PrivateKey {
			get { return ConfigurationManager.AppSettings["privateKey"]; }
		}

		public string ErrorMessageKey {
			get { return errorMessageKey; }
			set { errorMessageKey = value; }
		}

		#endregion Properties

		#region Private

		/// <summary>
		/// obtains the value of a key in the http form
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetFormValue( string value ) {
			return HttpContext.Current.Request.Form[value];
		}
	
		/// <summary>
		/// Gathers the parameters for reCaptchaValidator
		/// </summary>
		/// <returns></returns>
		private static string ReCaptchaParameters() {
			string response = GetFormValue("recaptcha_response_field");
			string challenge = GetFormValue("recaptcha_challenge_field");
			string IP = HttpContext.Current.Request.UserHostName;
			
			StringBuilder builder = new StringBuilder();
			 
			builder.AppendFormat( "privatekey={0}&", PrivateKey );
			builder.AppendFormat( "remoteip={0}&", IP );
			builder.AppendFormat( "challenge={0}&", challenge );
			builder.AppendFormat( "response={0}", response );
			
			return builder.ToString();
		}

		/// <summary>
		/// Validates the capcha inserted by the user
		/// </summary>
		/// <param name="parameters">parameters to verify</param>
		/// <returns>response of the capcth</returns>
		private static string ValidateCaptcha( string parameters ) {
			try {
				WebRequest request = WebRequest.Create( "http://api-verify.recaptcha.net/verify" );
			
				request.ContentType = "application/x-www-form-urlencoded";
				request.Method = "POST";
						
				StreamWriter writer = new StreamWriter( request.GetRequestStream() );
				writer.Write( parameters );
				writer.Close();
						
				//response
				HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
				StreamReader myReader = new StreamReader( webResponse.GetResponseStream() );

				string response = myReader.ReadToEnd();
						
				myReader.Close();
				webResponse.Close();

				return response;
			}catch( WebException ) {
				return string.Empty;
			}
		}
	
		#endregion Private

		#region Public

		protected override bool EvaluateIsValid() {
			string parameters = ReCaptchaParameters();

			string result = ValidateCaptcha(parameters);
			bool isValid = result.Equals("true\nsuccess");

			if( !isValid ) {
				ErrorMessage = LanguageManager.Instance.Get(errorMessageKey);
				Controls.Add( new LiteralControl(ErrorMessage));
			}

			return isValid;
		}
				
		#endregion Public

		#region Control Events

		protected override void OnInit(EventArgs e) {
			dummy.ID = "aaa";
			Controls.Add(dummy);
			ControlToValidate = "aaa";

			base.OnInit(e);
		}

		/// <summary>
		/// Writes the to show the validation Captcha
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render(HtmlTextWriter writer) {
			writer.Write( 
@"
<script>
var RecaptchaOptions = {{theme : 'blackglass', tabindex : 2}};
</script>
<script type='text/javascript' src='http://api.recaptcha.net/challenge?k={0}'></script>
<noscript>
   <iframe src='http://api.recaptcha.net/noscript?k={0}' height='300' width='500' frameborder='0'></iframe><br/>
   <textarea name='recaptcha_challenge_field' rows='3' cols='40'></textarea>
   <input type='hidden' name='recaptcha_response_field' value='manual_challenge'>
</noscript>", PublicKey );

			dummy.Visible = false;

			base.Render(writer);
		}

		#endregion Constructor
		
	}	
}
