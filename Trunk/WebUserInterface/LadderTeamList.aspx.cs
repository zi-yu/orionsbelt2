using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

	public class LadderTeamList: Page 
    {
	    protected TeamStoragePagedList paged;
        protected Literal pagination;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            string id = HttpContext.Current.Request.QueryString["Team"];
            int pId;
            if(Int32.TryParse(id,out pId))
            {
                IList<Principal> list;
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    list = persistance.TypedQuery("from SpecializedPrincipal where TeamID={0} or TeamID={1} order by TeamID", pId, Utils.Principal.Team.Id);
                }

                List<Principal> prins = new List<Principal>(list);

                FleetInfo fleetInfo = TournamentManager.GetFleet(1000,false);

                TournamentManager.CreateLadder4(prins, fleetInfo);
            }
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> list = persistance.SelectById(Utils.Principal.Id);
                HttpContext.Current.User = list[0];
            }
            //HttpContext.Current.Cache.Remove(Utils.Principal.Name);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int pageElems = 50;
            string page = HttpContext.Current.Request.QueryString["page"];

            SetStartPosition(page, pageElems);
            
            if (!State.InMemory("elemTeamNumber"))
            {
                GetElemNumber();
            }

            StringWriter sw = new StringWriter();
            WebUtilities.RenderPages(sw, Math.Ceiling(Convert.ToDouble(State.GetFromMemory("elemTeamNumber")) / pageElems));
            pagination.Text = sw.ToString();

            paged.FetchCollection();
            IList<TeamStorage> list = paged.Collection;
            if (list.Count > pageElems)
            {
                paged.Collection = ((List<TeamStorage>)list).GetRange(0, pageElems);
            }
            State.SetItems("LadderTeamCollection", list);

            MyLadderInfo(list);
        }

        private void SetStartPosition(string page, int pageElems)
        {
            if (string.IsNullOrEmpty(page))
            {
                if (!State.InMemory("ladderTeamCurrPage"))
                {
                    GetCurrPage();
                }

                paged.Start = (int)State.GetFromMemory("ladderTeamCurrPage") * pageElems;
            }
            else
            {
                paged.Start = Convert.ToInt32(page) * pageElems;
            }
        }

        private void MyLadderInfo(IList<TeamStorage> list)
	    {
            Principal current = HttpContext.Current.User as Principal;
            if (current == null || current.Team == null) {
                return;
            }
            int myIdx = IndexOf(current.Team, list);
	        State.SetItems("MyLadderTeamCollectionIdx", myIdx);

            //if (0 != current.Team.IsInBattle)
            //{
            //    battle.Text = string.Format("<a href='Battle.aspx?id={0}'>{1}</a>", current.Team.IsInBattle, LanguageManager.Instance.Get("YourBattle"));
            //}

	    }

        private static int IndexOf(IEntity teamStorage, IList<TeamStorage> list)
        {
            for (int i = 0; i < list.Count; ++i )
            {
                if (list[i].Id == teamStorage.Id)
                    return i;
            }
            return -1;
        }

	    private static void GetCurrPage()
	    {
            Principal current = HttpContext.Current.User as Principal;
            if (current == null || current.Team == null) {
                State.SetMemory("ladderTeamCurrPage", 0);
                return;
            }
            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
	        {
	            long init = persistance.ExecuteScalar(
                    "select count (*) from SpecializedTeamStorage where LadderPosition <= {0} and LadderActive = 1 and IsComplete = 1",
                    current.Team.LadderPosition);
	            double currPage = Math.Floor((double) init/50);
	            State.SetMemory("ladderTeamCurrPage", (int)currPage);
	        }
	    }

        private static void GetElemNumber()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                long init = persistance.ExecuteScalar("select count (*) from SpecializedTeamStorage where  LadderActive = 1");
                State.SetMemory("elemTeamNumber", (int)init);
            }
        }
	}
}
