using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

	public class LadderList: Page 
    {
	    protected PrincipalPagedList paged;
        protected Literal pagination, pagination1;
        protected override void OnInit(EventArgs e)
        {
			
            base.OnInit(e);
            
            string id = HttpContext.Current.Request.QueryString["Sing"];
            int pId;
            if(Int32.TryParse(id,out pId))
            {
                IList<Principal> list;
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    list = persistance.SelectById(pId);
                    list.Add(Utils.Principal);
                }

                List<Principal> prins = new List<Principal>(list);
				
                FleetInfo fleetInfo = TournamentManager.GetFleet(500, false);
                TournamentManager.CreateLadder(prins, fleetInfo);
			}
            
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> list = persistance.SelectById(Utils.Principal.Id);
                HttpContext.Current.User= list[0];
            }
            
            //HttpContext.Current.Cache.Remove(Utils.Principal.Name);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int pageElems = 50;
            string page = HttpContext.Current.Request.QueryString["page"];
            
            SetStartPosition(page, pageElems);

            if (!State.InMemory("elemNumber"))
            {
                WebUtilities.GetLadderElemNumber();
            }
            StringWriter sw = new StringWriter();
            WebUtilities.RenderPages(sw, Math.Ceiling(Convert.ToDouble(State.GetFromMemory("elemNumber")) / pageElems));
            pagination.Text = sw.ToString();
            pagination1.Text = pagination.Text;

            paged.FetchCollection();
            IList<Principal> list = paged.Collection;
            if (list.Count > pageElems)
            {
                paged.Collection = ((List<Principal>)list).GetRange(0, pageElems);
            }
            State.SetItems("LadderCollection", list);

            MyLadderInfo(list);
        }

	    private void SetStartPosition(string page, int pageElems)
	    {
	        if(string.IsNullOrEmpty(page))
	        {
	            if(!State.InMemory("ladderCurrPage"))
	            {
	                GetCurrPage();
	            }

	            paged.Start = (int)State.GetFromMemory("ladderCurrPage")*pageElems;
	        }
	        else
	        {
	            paged.Start = Convert.ToInt32(page)*pageElems;
	        }
	    }


	    private void MyLadderInfo(IList<Principal> list)
	    {
            Principal current = HttpContext.Current.User as Principal;
            if (current == null)
            {
                return;
            }

            int myIdx = IndexOf(list, current);
	        State.SetItems("MyLadderCollectionIdx", myIdx);

            //if(0 != current.IsInBattle)
            //{
            //    battle.Text = string.Format("<a href='Battle.aspx?id={0}'>{1}</a>", current.IsInBattle, LanguageManager.Instance.Get("YourBattle"));
            //}
	    }

        private static int IndexOf(IList<Principal> list, IEntity principal)
        {
            for (int i = 0; i < list.Count; ++i )
            {
                if (list[i].Id == principal.Id)
                    return i;
            }
            return -1;
        }

	    private static void GetCurrPage()
	    {
            Principal current = HttpContext.Current.User as Principal;
            if (current == null)
            {
                return;
            }
	        using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
	        {
	            long init = persistance.ExecuteScalar(
	                "select count (*) from SpecializedPrincipal where LadderPosition <= {0} AND LadderActive = 1",
                     current.LadderPosition);
	            double currPage = Math.Floor((double) init/50);              
	            State.SetMemory("ladderCurrPage", (int)currPage);

	        }
	    }


    }
}
