using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is available for construction
    /// </summary>
    public class DependencyFacilityNotRunningResult : RulesResultItem  {

        #region Ctor & Properties

        public DependencyFacilityNotRunningResult(string name)
            : base(string.Format("Resource must be running: {0}", name), name)
        {
        }

        public override bool Ok {
	        get { 
		         return false;
	        }
        }

        public override string Log(OrionsBelt.Generic.Messages.IMessageParameterTranslator translator)
        {
            return string.Format(translator.Translate(Name), translator.Translate(Params[0]));
        }

        #endregion Ctor & Properties

    };
}
