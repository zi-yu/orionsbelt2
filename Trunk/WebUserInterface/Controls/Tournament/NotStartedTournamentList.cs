using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Generic;
using OrionsBelt.TournamentCore;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents.Controls;
using System.Web.Caching;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class NotStartedTournamentList : TournamentList
    {
        #region Fields

        private static string key = "NotStartedTournamentList";

        #endregion Fields

        #region Private

        protected override IList<Core.Tournament> GetCollection() {
#if !DEBUG
            if (State.HasCache(key)) {
                return (IList<Core.Tournament>)State.GetCache(key);
            }
#endif
            IList<Core.Tournament> tournament = Hql.StatelessQuery<Core.Tournament>("select t from SpecializedTournament t where t.CreatedDate = t.StartTime and t.Token <> 'XLPartyTournament'");
            HttpContext.Current.Cache.Add(key, tournament, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);

            return tournament;
        }

        #endregion Private

    }
}