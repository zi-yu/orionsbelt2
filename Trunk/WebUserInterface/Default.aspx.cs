using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;
using System.Web.UI.WebControls;

namespace OrionsBelt.WebUserInterface {
	public class Default : Page {

        #region Fields

        protected MessageList playerMessages;
        protected PrivateBoardViewer board;
        protected Literal allianceBoardMessage;

        protected GlobalMessages globalMessages;

        #endregion Fields

        #region Events

		protected override void OnPreInit(System.EventArgs e)
		{
			base.OnPreInit(e);
			if (HttpContext.Current.User.IsInRole("guest")){
				HttpContext.Current.Response.Redirect(WebUtilities.LoginPath, true);
			}
			
		}
		
        protected override void OnLoad( System.EventArgs e ) 
        { 
            PrepareAllianceBoard();
            PrepareInteractions();
            TutorialManager.Current = Tutorial.Home;
        }

        private void PrepareAllianceBoard()
        {
            if (AllianceWebUtils.PlayerHasAlliance()) {
                board.ReceiverId = PlayerUtils.Current.Alliance.Storage.Id;
                board.ReceiverType = "Alliance";
            }
        }

        private static IList<Message> GetGlobalMessages()
        {
            if (State.HasCache("GlobalMessages")) {
                return (IList < Message >) State.GetCache("GlobalMessages");
            }

            IList<Message> messages = Hql.StatelessQuery<Message>("from SpecializedMessage m where m.Category = :category and (m.TickDeadline = 0 or m.TickDeadline = null or m.TickDeadline >= :tick) order by m.CreatedDate desc", Hql.Param("category", Category.Global.ToString()), Hql.Param("tick", Clock.Instance.Tick));
            State.Cache.Add("GlobalMessages", messages, null, DateTime.Now.AddMinutes(40), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return messages;
        }

        #endregion Events

        #region Interactions

        private void PrepareInteractions()
        {
            IList<Interaction> interactionList;
            if (AllianceWebUtils.PlayerHasAlliance() && PlayerUtils.Current.AllianceRank == AllianceRank.Admiral)
            {
                interactionList = AllianceManager.GetImportantInteractionsForHome(AllianceWebUtils.Current, Utils.Principal);

                if (PlayerUtils.Current.AllianceRank != AllianceRank.Admiral)
                {
                    IList<Interaction> temp = new List<Interaction>(interactionList);
                    
                    foreach (Interaction interaction in temp)
                    {
                        if(interaction.Type.Contains("Alliance"))
                        {
                            interactionList.Remove(interaction);
                        }
                    }
                }
            }
            else
            {
                interactionList = AllianceManager.GetImportantInteractions(null, Utils.Principal);
            }
            globalMessages.SetInteractions(interactionList);
            if (AllianceWebUtils.HasCurrent) {
                globalMessages.InteractionsState = AllianceWebUtils.Current.Storage;
            }
        }

        #endregion Interactions

		#region Some things for tests

		//private static void CreateResources() {
		//    ISystem s = PlayerUtils.Current.PrivateSystem;
		//    CreateResource(s, 1, 1);
		//    CreateResource(s, 1, 2);
		//    CreateResource(s, 1, 3);
		//    CreateResource(s, 2, 1);
		//    CreateResource(s, 2, 3);
		//    CreateResource(s, 3, 1);
		//    CreateResource(s, 3, 2);
		//    CreateResource(s, 3, 3);
		//    Persistance.Flush();
		//}

		//private static void CreateResource(ISystem s, int x, int y) {
		//    ISector sector = s.GetSector(new Coordinate(x, y));
		//    if (sector != null && sector is NormalSector) {
		//        ResourceSector r = new ResourceSector(new Coordinate(0, 0), new Coordinate(x, y), 1);
		//        r.Owner = PlayerUtils.Current;
		//        s.RemoveSector(sector.Coordinate.Sector);
		//        GameEngine.Persist(r, true, true);
		//        s.AddSector(r);
		//    }
		//}

		#endregion Some things for tests

	};
}

