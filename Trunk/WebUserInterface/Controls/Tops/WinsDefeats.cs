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
    public class WinsDefeats : BaseFieldControl<PlayerStorage>, INamingContainer
    {
        #region BaseFieldControl<AllianceStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, PlayerStorage entity, int renderCount, bool flipFlop)
        {
            IList info;
            if (!State.HasCache("PlayersBattles"))
            {
                using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
                {
                    
                    info =
                        persistance.Query(
                            @"SELECT p.Owner,p.HasLost,count(p) 
                                    FROM SpecializedPlayerBattleInformation p
                                    inner join p.BattleNHibernate b
                                    where b.HasEnded=1 and (b.BattleMode='Battle' or b.BattleMode='Arena')
                                    group by p.Owner,p.HasLost");

                    State.Cache.Add("PlayersBattles", info, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
                }
            }
            else
            {
                info = (IList)State.GetCache("PlayersBattles");
            }

            writer.Write(GetBattles(info, entity));
            //writer.Write("<span class='green'>{0}</span>/<span class='red'>");
            //<span class='green'>
        }

        private static string GetBattles(IList info, IEntity entity)
        {
            int wins = 0;
            int defeats = 0;

            foreach (IList list in info)
            {
                if(Convert.ToInt32(list[0]) == entity.Id)
                {
                    if(Convert.ToBoolean(list[1]))
                    {
                        defeats = Convert.ToInt32(list[2]);
                    }
                    else
                    {
                        wins = Convert.ToInt32(list[2]);
                    }
                }
                if(wins != 0 && defeats != 0)
                {
                    break;
                }
            }
            return string.Format("<span class='green'>{0}</span> / <span class='red'>{1}</span>", wins, defeats);
        }

        #endregion BaseFieldControl<AllianceStorage> Implementatio
    }
}
