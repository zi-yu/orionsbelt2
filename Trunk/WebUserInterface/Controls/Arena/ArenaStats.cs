using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ArenaStats : Control
    {
        private ArenaStorage arena;

        public ArenaStorage Arena
        {
            get { return arena; }
            set { arena = value; }
        }

        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<table>");
            WriteMaxSequence(writer);
            WriteDefenses(writer);
            WriteWinnings(writer);
            WriteTime(writer);
            writer.Write("</table>");  
        }


        #endregion Control Events 
 
        private void WriteTime(TextWriter writer)
        {
            int player = 0;
            int time = 0;

            if(arena.Historical.Count == 0)
                return;

            if(arena.Historical.Count == 1)
            {
                time = Clock.Instance.Tick - arena.ConquestTick;
            }
            else
            {
                int current = player;
                int beginTime = time;
                foreach (ArenaHistorical historical in arena.Historical)
                {
                    if (player == 0)
                    {
                        current = historical.Winner;
                        player = historical.Winner;
                        time = historical.EndTick;
                        beginTime = historical.EndTick;
                        continue;
                    }

                    if (historical.Winner != current && historical.Winner != 0)
                    {
                        int testTime = historical.EndTick - beginTime;
                        if (testTime > time)
                        {
                            time = testTime;
                            player = current;
                            beginTime = historical.EndTick;
                        }
                        current = historical.Winner;
                    }
                }
                int test = Clock.Instance.Tick - beginTime;
                if (test > time || arena.Historical.Count == 1)
                {
                    time = test;
                    player = current;
                }
            }
            string playerName = GetPlayerName(player);
            writer.Write("<tr><td>{0}</td><td><b>{1}</b></td><td>{2}</td></tr>",
                LanguageManager.Instance.Get("GreatestTime"),
                TimeFormatter.GetFormattedTicks(time),
                playerName);

        }
      
        private void WriteMaxSequence(TextWriter writer)
        {
            IList<ArenaHistorical> hists;
            string playerName;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                hists = persistance.TypedQuery(@"select a from SpecializedArenaHistorical a
                                                where a.ArenaNHibernate.Id={0} and
                                                a.WinningSequence like
                                                (SELECT max(h.WinningSequence) FROM SpecializedArenaHistorical h)", 
                                                arena.Id);
            
                if(hists.Count == 0)
                {
                    return;
                }

                playerName = GetPlayerName(hists[0].Winner, persistance);

            }
            writer.Write("<tr><td>{0}</td><td><b>{1}</b></td><td>{2}</td></tr>", 
                LanguageManager.Instance.Get("GreatestSequence"),
                hists[0].WinningSequence,
                playerName);
        }

        private void WriteWinnings(TextWriter writer)
        {
            IList hists;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                hists = persistance.Query(@"SELECT h.Winner, count(h.Winner)
                                                FROM SpecializedArenaHistorical h
                                                where h.ArenaNHibernate.Id={0} and
                                                h.WinningSequence <> 0
                                                GROUP BY h.Winner
                                                ORDER BY count(h.Winner) desc",
                                                arena.Id);

                if (hists.Count == 0)
                {
                    return;
                }

                int first = 0;
                foreach (IList hist in hists)
                {
                    string playerName;
                    if (first == 0)
                    {
                        first = int.Parse(hist[1].ToString());
                        playerName = GetPlayerName(int.Parse(hist[0].ToString()), persistance);
                        writer.Write("<tr><td>{0}</td><td><b>{1}</b></td><td>{2}</td></tr>",
                                   LanguageManager.Instance.Get("MoreWinnings"),
                                   first,
                                   playerName);
                    }
                    else
                    {
                        if (first == int.Parse(hist[1].ToString()))
                        {
                            playerName = GetPlayerName(int.Parse(hist[0].ToString()), persistance);
                            writer.Write("<tr><td></td><td><b>{0}</b></td><td>{1}</td></tr>",
                                       first,
                                       playerName);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        }

        private void WriteDefenses(TextWriter writer)
        {
            IList hists;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                hists = persistance.Query(@"SELECT h.Winner, count(h.Winner)
                                                FROM SpecializedArenaHistorical h
                                                where h.ArenaNHibernate.Id={0} and
                                                h.ChampionId=h.Winner
                                                GROUP BY h.Winner
                                                ORDER BY count(h.Winner) desc",
                                                arena.Id);

                if (hists.Count == 0)
                {
                    return;
                }

                int first = 0;
                foreach (IList hist in hists)
                {
                    string playerName;
                    if(first == 0)
                    {
                        first = int.Parse(hist[1].ToString());
                        playerName = GetPlayerName(int.Parse(hist[0].ToString()), persistance);
                        writer.Write("<tr><td>{0}</td><td><b>{1}</b></td><td>{2}</td></tr>",
                                   LanguageManager.Instance.Get("MoreDefenses"),
                                   first,
                                   playerName);
                    }
                    else
                    {
                        if(first == int.Parse(hist[1].ToString()))
                        {
                            playerName = GetPlayerName(int.Parse(hist[0].ToString()), persistance);
                            writer.Write("<tr><td></td><td><b>{0}</b></td><td>{1}</td></tr>",
                                       first,
                                       playerName);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

        }

        private static string GetPlayerName(int id, IPersistanceSession persistance)
        {
            string playerName;
            if (State.HasCache("arenaPlayer" + id))
            {
                playerName = (string)State.GetCache("arenaPlayer" + id);
            }
            else
            {
                using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                {
                    IList<PlayerStorage> player = persistance2.SelectById(id);
                    if(player.Count == 0)
                    {
                        playerName = string.Format("<i>{0}</i>", LanguageManager.Instance.Get("Unknown"));
                        State.SetCache("arenaPlayer" + id,
                                       playerName);
                    }
                    else
                    {
                        playerName = player[0].Name;
                        State.SetCache("arenaPlayer" + id, player[0].Name);
                    }

                }
            }
            return playerName;
        }

        private static string GetPlayerName(int id)
        {
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                return GetPlayerName(id, persistance);
            }
        }
    }
}
