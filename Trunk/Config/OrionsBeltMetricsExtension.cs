using Mono.GetOptions;
using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using Loki.Generic;
using Loki.Generic.Formatting;
using Loki.Generic.Metrics;
using Loki.DataRepresentation;
using System.Reflection;
using System.Web.Security;

namespace OrionsBelt.Config {
	
	public partial class OrionsBeltConfig {
	
		#region Metrics

        [Option("Processes application's metrics", "metrics")]
        public WhatToDoNext RunMetrics()
        {
            Metrics.Log( typeof(Persistance).Assembly );

            return WhatToDoNext.GoAhead;
        }

        #endregion Metrics
        
        #region Metrics

        [Option("Processes metrics reports", "metrics-reports")]
        public WhatToDoNext RunMetricsReports()
        {
            Metrics.GenerateReports();

            return WhatToDoNext.GoAhead;
        }

        #endregion Metrics

	};

}