
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PaymentNumberPagination : BaseNumberPagination<Payment> {

        #region BasePagination Implementation

        protected override long GetTotalItems() {
            return Persistance.GetEntityCount<Payment>();
        }

        #endregion BasePagination Implementation

    };

}