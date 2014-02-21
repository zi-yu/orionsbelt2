using System;
namespace OrionsBelt.Engine.Common {

    public class EngineException : Core.OrionsBeltException {

        #region Ctors

        public EngineException(string str, params object[] args)
            : base(str, args)
        {
        }

        public EngineException(Exception ex, string str)
            : base(str, ex)
        {
        }

        public EngineException(Exception ex, string str, params string[] args)
            : base(str, ex, args)
        {
        }

        #endregion Ctors

    };

}
