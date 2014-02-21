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
using System.Reflection;
using System.Web.Security;
using Loki.DataRepresentation;

namespace OrionsBelt.Config {
	
	public class EntityCountMetrics : Metrics {
	
		#region Metrics Implementation

        protected override void WriteMetrics(TextWriter writer)
        {
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                foreach (Type type in Persistance.GetPersistableTypes()) {
                    if (!IsToLog(type)) {
                        continue;
                    }
                    long count = session.ExecuteScalar("select count(e) from Specialized{0} e", type.Name);
                    WriteValue(writer, type.Name, count);
                }
            }
        }

        private bool IsToLog(Type type)
        {
            return type.Name != "Principal";
        }

        #endregion Metrics Implementation

	};

}