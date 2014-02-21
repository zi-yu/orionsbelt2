using System;
using System.Collections;
using System.Web.Caching;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ELOWinsDefeats : BaseFieldControl<Principal>, INamingContainer
    {
        #region BaseFieldControl<AllianceStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Principal entity, int renderCount, bool flipFlop)
        {
            IList info;
            if (!State.HasCache("PrincipalBattlesStats"))
            {
                using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
                {
                    
                    info =
                        persistance.Query(
                            @"SELECT p.Id,sum(b.Wins), sum(b.Defeats) FROM SpecializedPrincipalStats p
                            inner join p.BattleStatsNHibernate b
                            group by p.Id");

                    State.Cache.Add("PrincipalBattlesStats", info, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
                }
            }
            else
            {
                info = (IList)State.GetCache("PrincipalBattlesStats");
            }

            writer.Write(GetBattles(info, entity));
            //writer.Write("<span class='green'>{0}</span>/<span class='red'>");
            //<span class='green'>
        }

        private static string GetBattles(IList info, Principal entity)
        {
            int wins = 0;
            int defeats = 0;

            foreach (IList list in info)
            {
                if (Convert.ToInt32(list[0]) == entity.MyStatsId)
                {
                    wins = Convert.ToInt32(list[1]);
                    defeats = Convert.ToInt32(list[2]);
                    break;
                }
            }
            return string.Format("<span class='green'>{0}</span> / <span class='red'>{1}</span>", wins, defeats);
        }

        #endregion BaseFieldControl<AllianceStorage> Implementatio
    }
}
