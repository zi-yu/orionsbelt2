using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public class SMS : PaymentBase {
		#region Fields

		

		#endregion Fields

		#region Private

		private static Dictionary<string, string> LoadServers() {
			Dictionary<string, string> servers = new Dictionary<string, string>();
			
			servers.Add("http://sirius.orionsbelt.eu/", "s1");
            servers.Add("http://s1.orionsbelt.eu/", "s1");
			
			return servers;
		}

		private static string GetServer() {
			IDictionary<string, string> servers;
			if( !State.HasCache("Servers") ) {
				servers = LoadServers();
				State.SetCache("Servers", servers);
			}else {
				servers = (Dictionary<string, string>)State.GetCache("Servers");
			}

			string server = "s0";
			if(servers.ContainsKey(Server.Properties.BaseUrl)){
				server = servers[Server.Properties.BaseUrl];
			}

			return server;
		}

		#endregion Private

		#region IPayment Interface

		/// <summary>
        /// Gets the string for a button with a paypal request
        /// </summary>
        /// <param name="principal">Principal that will do the payment</param>
        /// <param name="currency">Currency of the payment</param>
		/// <param name="paymentDescription">Payment Description</param>
        /// <returns>String representing the code that make a request</returns>
        public override string Render(Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription){
			StringWriter writer = new StringWriter();
			writer.Write("<div class='chooseAmmount'><div class='paymentDescriptionSms'>");
			writer.Write("<div class='cost'>{0}: {1}€</div>", LanguageManager.Instance.Get("Cost"), paymentDescription.Cost);
			writer.Write("<div>{0}: {1}  <b>+</b></div>", LanguageManager.Instance.Get("Orions"), paymentDescription.Amount);
			writer.Write("<div>{0}: {1}</div>", LanguageManager.Instance.Get("BonusOrions"), paymentDescription.Bonus);
			writer.Write("<div>{0}: {1}</div>", LanguageManager.Instance.Get("Number"), paymentDescription.Data);
			writer.Write("<div>{0}: ob {1} {2}</div>", LanguageManager.Instance.Get("Message"), GetServer(), Utils.Principal.Id);
			writer.Write("</div></div>");
        	return writer.ToString();
        }

		/// <summary>
        /// Validate the request
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <returns>Validation result</returns>
        public override bool IsValidRequest(Dictionary<string, string> parameters, string request)
        {
            if (!ValidateIP(request, parameters))
            {
                Logger.Info(LogType.SMS, "invalid IP");
                return false;
            }

            if (!ValidateNumber(parameters))
            {
                Logger.Info(LogType.SMS, "invalid number");
                return false;
            }

            if (!ValidateMessage(parameters))
            {
                Logger.Info(LogType.SMS, "invalid message");
                return false;
            }
            Logger.Info(LogType.SMS, "Validated");
            return true;
        }


        public override void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            string[] sms = parameters["text"].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int principalId = Int32.Parse(sms[2]);
            Logger.Info(LogType.SMS, string.Format("User id={0}",principalId));
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> principals = persistance.SelectById(principalId);

                if (!ValidatePrincipal(parameters, persistance, principalId, principals))
                {
                    Logger.Info(LogType.SMS, "invalid principal");
                    return;
                }
                MakePayment(parameters, message, principalId.ToString(), null);
                //Afectar as tabelas de payment, transaction e por orions no principal
            }
        }

        /// <summary>
        /// Log a request well recieved but not yet verified
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <param name="exception">Comunication exception</param>
        protected override void WriteNotVerified(Dictionary<string, string> parameters, string request, WebException exception)
        {
            return;
        }

        /// <summary>
        /// Make all payment process
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="message">Request string (paramenters in string)</param>
        /// <param name="principalId">RPrincipal identifier</param>
        /// <param name="retry">If is not null is a retry</param>
        protected override void MakePayment(Dictionary<string, string> parameters, string message, string principalId, Payment retry)
        {
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                persistance.StartTransaction();

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(principalId);
                    retry.Method = PaymentMethodEnum.SMS.ToString();
                    retry.Request = message;
                    retry.RequestId = parameters["momId"];
                    retry.Ammount = GetAmmount(parameters["shortCode"]);
                    
                }
                retry.VerifyState = "Verified";
                Logger.Info(LogType.SMS, "table payment afected");
                persistance.Update(retry);
                Principal payer;
                int orions = GetOrions(Convert.ToDouble(retry.Ammount));
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance())
                {
                    payer = persistance2.SelectById(retry.PrincipalId)[0];
                    payer.Credits += orions;
                    persistance2.Update(payer);
                    Logger.Info(LogType.SMS, "orions incremented");
                }

                TransactionManager.PaymentTransaction(payer, retry, orions,Convert.ToDouble(retry.Ammount),persistance);
                Logger.Info(LogType.SMS, "table transactions afected");
                persistance.CommitTransaction();
                persistance.Flush();
            }
            
        }

        /// <summary>
        /// Make the payment invalid
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="message">Request string (paramenters in string)</param>
        /// <param name="response">Response string</param>
        /// <param name="retry">If is not null is a retry</param>
        protected override void MakeInvalid(Dictionary<string, string> parameters, string message, string response, Payment retry)
        {
            return;
        }

        #endregion IPayment Interface

        #region Private Methods

        private static bool ValidateNumber(IDictionary<string, string> parameters)
        {
            if (!PaymentUtils.NumberAmmount.ContainsKey(parameters["shortCode"]))
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = 0;
                    p.Method = PaymentMethodEnum.SMS.ToString();
                    p.Request = parameters["text"]; 
                    p.RequestId = parameters["momId"];
                    p.Ammount = "Invalid";
                    p.VerifyState = "InvalidAmmount";
                    p.Parameters = string.Format("Receiver:{0}; Sender:{1}", parameters["shortCode"], parameters["msisdn"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool ValidateMessage(IDictionary<string, string> parameters)
        {
            string[] message = parameters["text"].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int aux;
            if (message.Length != 3 || !Int32.TryParse(message[2], out aux))
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = 0;
                    p.Method = PaymentMethodEnum.SMS.ToString();
                    p.Request = parameters["text"];
                    p.RequestId = parameters["momId"];
                    p.Ammount = GetAmmount(parameters["shortCode"]);
                    p.VerifyState = "InvalidMessage";
                    p.Parameters = string.Format("Receiver:{0}; Sender:{1}", parameters["shortCode"], parameters["msisdn"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool ValidateIP(string request, IDictionary<string, string> parameters)
        {
            Logger.Info(LogType.SMS, "IP:{0}", request);
            if (request != ConfigurationManager.AppSettings["validIP"])
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = 0;
                    p.Method = PaymentMethodEnum.SMS.ToString();
                    p.Request = parameters["text"];
                    p.RequestId = parameters["momId"];
                    p.Ammount = GetAmmount(parameters["shortCode"]);
                    p.VerifyState = "InvalidIP";
                    p.Parameters = string.Format("IP:{0}", request);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static string GetAmmount(string number)
        {
            if (!PaymentUtils.NumberAmmount.ContainsKey(number))
            {
                return "Invalid";
            }
            return PaymentUtils.NumberAmmount[number];
        }

        /// <summary>
        /// Get number of Orions for a payment
        /// </summary>
        /// <param name="payMoney">Money payed</param>
        /// <returns>number of Orions</return
        protected override int GetOrions(double payMoney)
        {
            if (payMoney == 2)
            {
                return 400;
            }
            if (payMoney == 4)
            {
                return 900;
            }

            return 0;
        }


        private static bool ValidatePrincipal(IDictionary<string, string> parameters, IPersistanceSession persistance, int principalId, IList<Principal> principals)
        {
            if (principals.Count == 0)
            {
                using (IPaymentPersistance persistance2 = Persistance.Instance.GetPaymentPersistance(persistance))
                {
                    Payment p = persistance2.Create();
                    p.PrincipalId = principalId;
                    p.Method = PaymentMethodEnum.SMS.ToString();
                    p.Request = parameters["text"];
                    p.RequestId = parameters["momId"];
                    p.Ammount = GetAmmount(parameters["shortCode"]);
                    p.VerifyState = "InvalidPrincipal";
                    p.Parameters = string.Format("Receiver:{0}; Sender:{1}", parameters["shortCode"], parameters["msisdn"]);
                    persistance2.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        #endregion Private Methods

	}
}
