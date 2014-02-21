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
	
	public class UserMetrics : Metrics {
	
		#region Metrics Implementation

        protected override void WriteMetrics(TextWriter writer)
        {
            WriteNewPlayers(writer);
            WriteActivePlayers(writer);
            WriteTotalRegisteredPlayer(writer);
            WriteLastDayLogins(writer);
        }
        
        private void WriteLastDayLogins(TextWriter writer)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                long count = persistance.ExecuteScalar("select count(*) from SpecializedPrincipal p where p.LastLogin > '{0}'", GetDate(-1));
                WriteValue(writer, "LastDayLogins", count);
            }
        }

        private void WriteNewPlayers(TextWriter writer)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                long count = persistance.ExecuteScalar("select count(*) from SpecializedPrincipal p where p.RegistDate between '{0}' and '{1}'", GetDate(-7), GetDate(0));
                WriteValue(writer, "NewUsers", count);
            }
        }

        private void WriteTotalRegisteredPlayer(TextWriter writer)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                long count = persistance.ExecuteScalar("select count(*) from SpecializedPrincipal p");
                WriteValue(writer, "RegisteredUsers", count);
            }
        }

        private void WriteActivePlayers(TextWriter writer)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                long count = persistance.ExecuteScalar("select count(*) from SpecializedPrincipal p where p.LastLogin > '{0}' and p.RegistDate <= '{1}'", GetDate(-7), GetDate(-30));
                WriteValue(writer, "ActiveUsers", count);
            }
        }

        #endregion Metrics Implementation

	};

}