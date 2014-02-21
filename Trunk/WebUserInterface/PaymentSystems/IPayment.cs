using System.Collections.Generic;
using System.Net;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public interface IPayment
    {
        /// <summary>
        /// Gets the string for a button with a paypal request
        /// </summary>
        /// <param name="principal">Principal that will do the payment</param>
        /// <param name="currency">Currency of the payment</param>
        /// <param name="paymentDescription">Payment Description</param>
        /// <returns>String representing the code that make a request</returns>
		string Render(Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription);

        /// <summary>
        /// Checks if a monetary value is valide
        /// </summary>
        /// <param name="quantity">Money ammount</param>
        /// <returns>Validation result</returns>
        bool IsValidQuantity(double quantity);

        /// <summary>
        /// Account mail
        /// </summary>
        string Mail { get;}

        /// <summary>
        /// Service Url
        /// </summary>
        string Url { get;}

        /// <summary>
        /// Validate the request
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <returns>Validation result</returns>
        bool IsValidRequest(Dictionary<string, string> parameters, string request);

        /// <summary>
        /// Send validation message
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <param name="retry">If is not null is a retry</param>
        void SendValidation(Dictionary<string, string> parameters, string request, Payment retry);
    }
}
