using System;
using System.IO;
using System.Web.Caching;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using System.Web;

namespace OrionsBelt.WebUserInterface.Controls {

	public class SiteFooter: Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            WriteNumbers(writer);
        }

        #endregion Rendering

        #region Numbers

        private static void WriteNumbers(TextWriter writer)
        {
            writer.Write("<ul id='gamestats'>");
            //writer.Write("<li class='tick'>{0} <b>{1}</b></li>", LanguageManager.Instance.Get("Tick"), Clock.Instance.Tick);
            if (HttpContext.Current.User.IsInRole("gameMaster")) {
                WriteDatabaseNumbers(writer);
            }
            //writer.Write("<li class='space'></li>");
            //writer.Write("<li>{0}: <b>{1}</b></li>", LanguageManager.Instance.Get("UniverseAge"), TimeFormatter.GetFormattedTicksSince(1));
            writer.Write("</ul>");
        }

        private static void WriteDatabaseNumbers(TextWriter writer)
        {
            writer.Write("<li><b>{0}</b> {1}</li>", GetOnlinePlayers(), LanguageManager.Instance.Get("Online"));
            string key = string.Format("SiteFooter-{0}", LanguageManager.CurrentLanguage);

            if (HttpContext.Current.User.IsInRole("admin")) {
                writer.Write("<li><b>{0}</b> {1}</li>", GetRealActivePlayers(), "Real Active");
            }

            if (State.HasFileCache(key)) {
                writer.Write(State.GetFileCache(key));
            } else {
                TextWriter tmp = new StringWriter();
                //tmp.Write("<li><b>{0}</b> {1}</li>", GetActivePlayers(), LanguageManager.Instance.Get("ActivePlayers"));
                tmp.Write("<li><b>{0}</b> {1}</li>", GetRegisteredPlayers(), LanguageManager.Instance.Get("RegisteredPlayers"));
                //tmp.Write("<li class='space'></li>");
                //tmp.Write("<li><b>{0}</b> {1}</li>", GetTotalBattles(), LanguageManager.Instance.Get("TotalBattles"));
                // tmp.Write("<li><b>{0}</b> {1}</li>", GetActiveBattles(), LanguageManager.Instance.Get("RunningBattles"));
                //tmp.Write("<li class='space'></li>");
                //tmp.Write("<li><b>{0}</b> {1}</li>", GetTotalItems(), LanguageManager.Instance.Get("TotalItems"));
                //tmp.Write("<li><b>{0}</b> {1}</li>", GetSellingItems(), LanguageManager.Instance.Get("SellingItems"));

                writer.Write(tmp.ToString());
                State.SetFileCache(key, tmp.ToString(), TimeSpan.FromDays(1));
            }
        }

        private static int GetRealActivePlayers()
        {
            GetActivePlayers();
            return Convert.ToInt32(State.GetCache("ActivePlayers"));
        }

        private static int GetTotalItems()
        {
            if (State.HasCache("TotalItemsInAH")) {
                return State.GetCacheInt("TotalItemsInAH");
            }

            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(e) from SpecializedAuctionHouse e where e.BuyedInTick > 0"));
            State.SetCache("TotalItemsInAH", total);
            return total;
        }

        private static int GetSellingItems()
        {
            if (State.HasCache("SellingItemsInAH"))
            {
                return State.GetCacheInt("SellingItemsInAH");
            }

            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(e) from SpecializedAuctionHouse e where e.BuyedInTick = 0"));
            State.SetCache("SellingItemsInAH", total);
            return total;
        }

        private static int GetActiveBattles()
        {
            if (State.HasCache("ActiveBattles")) {
                return State.GetCacheInt("ActiveBattles");
            }

            int total = Convert.ToInt32( Hql.ExecuteScalar("select count(*) from SpecializedBattle b where b.HasEnded = 0") );
            State.SetCache("ActiveBattles", total);
            return total;
        }

        private static int GetTotalBattles()
        {
            if (State.HasCache("TotalBattles")) {
                return State.GetCacheInt("TotalBattles");
            }

            int total = Convert.ToInt32( Hql.ExecuteScalar("select count(*) from SpecializedBattle") );
            State.SetCache("TotalBattles", total);
            return total;
        }

        private static int GetOnlinePlayers()
        {
            int online;
            if (State.HasCache("OnlinePlayers")) {
                online = State.GetCacheInt("OnlinePlayers");
            } else {
                long count;
                using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                    count = session.ExecuteScalar("SELECT count(*) FROM SpecializedPlayerStorage t where t.UpdatedDate > '{0}'", (DateTime.Now.AddMinutes(-15)).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                online = Convert.ToInt32(count);
                State.Cache.Add("OnlinePlayers", online, null, DateTime.Now.AddMinutes(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }

            if (Utils.Principal.IsInRole("admin")) {
                return online;
            }

            double total = GetActivePlayers();
            double threshold = total * 0.05;
            if (threshold > online) {
                online = Convert.ToInt32(threshold + rnd.Next(0, 10));
            } 

            return online;
        }

        private static readonly Random rnd = new Random();
        private static int dummyActive = 0;
        private static int GetActivePlayers()
        {
            int active;
            if (State.HasCache("ActivePlayers")) {
                active = State.GetCacheInt("ActivePlayers");
            } else {
                long count;
                using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                    count = session.ExecuteScalar("SELECT count(*) FROM SpecializedPlayerStorage t where t.LastProcessedTick > {0} and t.CreatedDate < '{1}'",
                                                TickClock.Instance.Tick - (144 * 7), DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd hh:mm:ss"));
                }
                active = Convert.ToInt32(count);
                State.SetCache("ActivePlayers", active);
            }

            if (dummyActive > 0) {
                return dummyActive;
            }

            double total = GetRegisteredPlayers();
            double threshold = total * 0.2;
            if (threshold > active) {
                dummyActive = Convert.ToInt32(threshold + rnd.Next(-10, 30));
            } else {
                dummyActive = active;
            }

            return dummyActive;
        }

        private static int GetRegisteredPlayers()
        {
            if (State.HasCache("RegisteredPlayers")) {
                return State.GetCacheInt("RegisteredPlayers");
            }

            int total = Convert.ToInt32( Hql.ExecuteScalar("select count(*) from SpecializedPrincipal") );
            State.SetCache("RegisteredPlayers", total);
            return total;
        }

        #endregion Numbers

    };
}

