using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalNumberPagination : BaseNumberPagination<Principal> {

        #region BasePagination Implementation

        protected override long GetTotalItems() {
            using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
                return persistance.SelectByLadderActive(true).Count;
            }
        }

        #endregion BasePagination Implementation

    };

}