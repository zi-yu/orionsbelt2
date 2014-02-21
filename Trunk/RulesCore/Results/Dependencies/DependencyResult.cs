using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is available for construction
    /// </summary>
    public class DependencyResult : RulesResultItem  {

        #region Ctor & Properties

        public DependencyResult(string name, int level, bool available)
            : base(string.Format("Resource available: {0} level {1}", name, level), name, level.ToString())
        {
            this.available = available;
        }

        private bool available = false;
        public override bool Ok {
	        get { 
		         return available;
	        }
        }

        public override string Log(OrionsBelt.Generic.Messages.IMessageParameterTranslator translator)
        {
            return string.Format(translator.Translate(Name), translator.Translate(Params[0]), Params[1]);
        }

        #endregion Ctor & Properties

    };
}
