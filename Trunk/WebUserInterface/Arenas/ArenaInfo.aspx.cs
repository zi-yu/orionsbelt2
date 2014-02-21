using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Controls;
using System.Web.UI.WebControls;
using System.Resources;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

    public class ArenaInfo : Page 
    {
        protected ArenaFleetRender fleetRender;
        protected ChampionFor championFor;
        protected DiscoveredAt discoveredAt;
        protected ArenaStats arenaStats;
        protected CurrentWinningSequence current;
        protected HtmlControl battlePlace;
        protected Literal name;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            int arenaId = Int32.Parse(HttpContext.Current.Request.QueryString["ArenaStorage"]);
            ArenaStorage arena;

            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena = persistance.SelectById(arenaId)[0];
            }

            fleetRender.Arena = arena;
            championFor.Arena = arena;
            discoveredAt.Arena = arena;
            arenaStats.Arena = arena;
            current.Arena = arena;
            name.Text = arena.Name;

            if (arena.IsInBattle != 0) {
                LatestMoves battle = new LatestMoves();
                battle.SpecificBattle = arena.IsInBattle;
                battlePlace.Controls.Add(battle);
            } else {
                battlePlace.Controls.Add(new LiteralControl(LanguageManager.Localize("NoBattle")));
            }
        }
    }
}
