using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Common {

    public class RulesException : OrionsBelt.Core.OrionsBeltException {

        #region Ctors

        public RulesException(string str, params object[] args)
            : base(str, args)
        {
        }

        #endregion Ctors

    };

}
