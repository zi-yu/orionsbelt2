using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.Generic;
using System;
using System.IO;
using System.Globalization;
using OrionsBelt.WebUserInterface.WebBattle;
using System.Web.Caching;
using System.Configuration;

namespace OrionsBelt.WebUserInterface.Engine {

    public delegate void PostBackActionHandler(string type, string action, string data);

	public static class WebUtilities {

		#region Fields

		private static readonly string path;
		private static readonly OBUserProvider provider = new OBUserProvider();

		#endregion Fields

		#region Properties

		public static string ApplicationPath {
			get { return path; }

		}

		public static OBUserProvider OBUserProvider {
			get { return provider; }
		}

        public static string LoginPath {
            get { return "~/Login.aspx"; }
        }

        public static bool IsForumAvailable {
            get { 
                  string forumActive = ConfigurationSettings.AppSettings["ForumActive"];
                  if (string.IsNullOrEmpty(forumActive) || (!string.IsNullOrEmpty(forumActive) && forumActive == "0")) {
                      return Utils.PrincipalExists && Utils.Principal.IsInRole("admin");
                  }
                  return true;
            }
        }

	    #endregion Properties

        #region Ctor
        
        static WebUtilities() {
			path = HttpContext.Current.Request.ApplicationPath;
			char bs = path[path.Length - 1];
			if (bs != '/') {
				path += "/";
			}
        }

        #endregion Ctor

        #region PostBackActions

        internal static void PreparePostBackActions(Page page)
        {
            page.ClientScript.RegisterHiddenField("doAction_type", string.Empty);
            page.ClientScript.RegisterHiddenField("doAction_action", string.Empty);
            page.ClientScript.RegisterHiddenField("doAction_data", string.Empty);
        }

        internal static string GetActionJs(string type, string action, object data)
        {
            return GetActionJs(type, action, data, false);
        }

        internal static string GetActionJs(string type, string action, object data, bool askConfirmation)
        {
            return string.Format("javascript:Utils.doAction(\"{0}\",\"{1}\",\"{2}\",{3});", type, action, data, askConfirmation.ToString().ToLower());
        }

        public static void ProcessPostBackAction(Page page, PostBackActionHandler handler, string typeFilter)
        {
            if (!page.IsPostBack) {
                return;
            }

            string type = page.Request.Form["doAction_type"];
            string action = page.Request.Form["doAction_action"];
            string data = page.Request.Form["doAction_data"];

            if (string.IsNullOrEmpty(type) || type != typeFilter) {
                return;
            }

            handler(type, action, data);
        }

        #endregion PostBackActions

        #region Comparers

        public static int Compare(IResourceInfo r1, IResourceInfo r2)
        {
            return LanguageManager.Instance.Get(r1.Name).CompareTo(LanguageManager.Instance.Get(r2.Name));
        }

        #endregion Comparers

        #region Time formatting

        public static string GetFormattedTicks(int ticks)
        {
            return TimeFormatter.GetFormattedTicks(ticks);
        }

        public static string GetFormattedTicksSince(int ticks)
        {
            return TimeFormatter.GetFormattedTicksSince(ticks);
        }

        public static string GetFormattedTime(TimeSpan span)
        {
            return TimeFormatter.GetFormattedTime(span);
        }

        #endregion Time formatting

        #region Frames

        internal static string WriteFrame(string url)
        {
            TextWriter writer = new StringWriter();

            writer.Write("<frameset rows=\"25px,*\" border=\"0\">");
            writer.Write("<frame noresize=\"noresize\" src =\"{0}GlobalMenu.aspx\" />", ApplicationPath);
            writer.Write("<frame noresize=\"noresize\" src =\"{0}\" />", url);
            writer.Write("</frameset>");
            
            return writer.ToString();
        }

        #endregion Frames

        #region Pagination

        public static void RenderPages(TextWriter writer, double numberOfPages, string addQueryString)
        {
            int page = 0;
            string s = HttpContext.Current.Request.QueryString["page"];
            if (!string.IsNullOrEmpty(s)) {
                int.TryParse(s, out page);
            }

            for (int iter = 0; iter < numberOfPages; ++iter)
            {
                if (page == iter) {
                    writer.Write("<b>{0}</b>", iter+1);
                } else { 
                    writer.Write("<a href='{0}?page={1}{3}'>{2}</a> ", HttpContext.Current.Request.Url.AbsolutePath, iter,
                             iter + 1, addQueryString);
                }
            }
        }

        public static void RenderPages(TextWriter writer, double numberOfPages)
        {
            RenderPages(writer, numberOfPages, string.Empty);
        }

        #endregion Pagination

        #region Battles

        public static int BattleReferenceTick{
            get { return Clock.Instance.Tick - 5; }
        }

        #endregion Battles

        #region HasBattles

	    public static bool HasBattles {
	        get {
	            string key = "HasBattles" + PlayerUtils.Current.Name;

                if (!State.HasCache(key)) {
                    SetHaveBattles();
                }
                return (bool)State.GetCache(key);
	        }set {
                ForceBattle(value, "HasBattles");
	        }
	    }

        public static bool HasUniverseBattles {
            get {
                string key = "HasUniverseBattles" + PlayerUtils.Current.Name;
                if (!State.HasCache(key)) {
                    SetHaveBattles();
                }
                return (bool)State.GetCache(key);
            }
            set {
                ForceBattle(value, "HasUniverseBattles");
            }
        }

	    public static void RemoveHasBattles() {
            HttpContext.Current.Cache.Remove("HasBattles" + PlayerUtils.Current.Name);
            HttpContext.Current.Cache.Remove("HasUniverseBattles" + PlayerUtils.Current.Name);
	    }

        private static void SetHaveBattles() {
            string[] hql = new string[2];
            hql[0] = string.Format(@"select Count(b) from SpecializedBattle b inner join b.PlayerInformationNHibernate p where b.HasEnded = 0 and
                        (
                            (
                                b.IsDeployTime = 0 and
                                (
                                    (b.BattleMode = 'Friendly' and b.CurrentPlayer = {0} ) or
                                    (b.BattleMode = 'Tournament' and b.CurrentPlayer = {0} ) or
                                    (b.BattleMode = 'Campaign' and b.CurrentPlayer = {0} ) or
                                    (b.BattleMode = 'Battle' and b.CurrentPlayer = {1} ) or
                                    (b.BattleMode = 'Arena' and b.CurrentPlayer = {1})
                                )
                            )
                            or
                            (
                                b.IsDeployTime = 1 and p.HasPositioned = 0 and (p.Owner={0} or p.Owner={1}) and
                                (
                                    ( b.BattleMode = 'Friendly' and p.Owner = {0} ) or
                                    ( b.BattleMode = 'Tournament' and p.Owner = {0} ) or
                                    ( b.BattleMode = 'Campaign' and p.Owner = {0} ) or
                                    ( b.BattleMode = 'Battle' and p.Owner = {1} ) or
                                    ( b.BattleMode = 'Arena' and p.Owner = {1})
                                )
                            )
                        )", Utils.Principal.Id, PlayerUtils.Current.Id);

            hql[1] = string.Format(@"select Count(b) from SpecializedBattle b inner join b.PlayerInformationNHibernate p inner join b.TimedActionNHibernate t where 
                        b.HasEnded = 0 and t.StartTick < {1} and
                        (
                            (
                                b.IsDeployTime = 0 and
                                (
                                    ( b.BattleMode = 'Battle' and b.CurrentPlayer = {0} ) or
                                    ( b.BattleMode = 'Arena' and b.CurrentPlayer = {0} )
                                )
                            )
                            or
                            (
                                b.IsDeployTime = 1 and p.HasPositioned=0 and p.Owner={0} and
                                (
                                    ( b.BattleMode = 'Battle' and p.Owner = {0} ) or
                                    ( b.BattleMode = 'Arena' and p.Owner = {0})
                                )
                            )
                        )", PlayerUtils.Current.Id, BattleReferenceTick);


            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
                IList results = persistance.MultiQuery(hql, new Dictionary<string, object>());
                object battlesObj = ((ArrayList)results[0])[0];
                object universeBattlesObj = ((ArrayList)results[1])[0];
                int battleCount = int.Parse(battlesObj.ToString());
                int universeBattleCount = int.Parse(universeBattlesObj.ToString());

                ForceHasBattles(battleCount > 0);
                ForceHasUniverseBattles(universeBattleCount > 0);

                return;
            }
        }

        private static void ForceHasBattles(bool haveBattles) {
            ForceBattle(haveBattles, "HasBattles");
        }

        private static void ForceHasUniverseBattles(bool haveBattles) {
            ForceBattle(haveBattles, "HasUniverseBattles");
        }

        private static void ForceBattle(bool haveBattles, string cacheName) {
            string key = cacheName+PlayerUtils.Current.Name;
            if (State.HasCache(key)) {
                HttpContext.Current.Cache.Remove(key);
            }
            HttpContext.Current.Cache.Add(key, haveBattles, null, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.Normal, null);
        }

        #endregion HasBattles

        #region Messages
        public static bool HaveMessages()
        {
            IPlayer player = PlayerUtils.Current;
            object count = Hql.ExecuteScalar(@"select Count(b) from SpecializedPrivateBoard b where b.Type='Player' and b.Receiver=:player and b.WasRead=0",
                                           Hql.Param("player", PlayerUtils.Current.Id));

            if (null == count)
            {
                return false;
            }

            return (long)count != 0;
        }

        public static void ForceHasMessages(bool haveBattles)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["HasMessages"];
            if (cookie == null)
            {
                cookie = new HttpCookie("HasMessages", haveBattles.ToString());
            }
            else
            {
                cookie.Value = haveBattles.ToString();
            }

            cookie.Expires = DateTime.Now.AddMinutes(5);
            HttpContext.Current.Request.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        #endregion Messages

        #region Player and Principal Url

        public static string GetBattlePlayerUrl(BattleMode battleMode, IBattlePlayer player){
            if(null == player)
            {
                return string.Empty;
            }
			if (battleMode == BattleMode.Battle || battleMode == BattleMode.Arena) {
                return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>", ApplicationPath, player.Owner.Id, player.Name); ;
			}
            return string.Format("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", ApplicationPath, player.Owner.Id, player.Name); ;
		}

        public static string GetBattlePlayerUrl(BattleMode battleMode, string name, int id) {
			if (battleMode == BattleMode.Battle || battleMode == BattleMode.Arena) {
				return PlayerUrl(name, id);
			}
			return PrincipalUrl(name, id);
		}

		public static string PlayerUrl( string name, int id ){
            string key = GetPlayerAvatarCacheKey(id);
            if (State.HasFileCache(key)) {
                return State.GetFileCache(key);
            }
            string avatar = (string) Hql.ExecuteScalar("select p.Avatar from SpecializedPlayerStorage p where p.Id = :id", Hql.Param("id", id));
            if (string.IsNullOrEmpty(avatar)) {
                avatar = ResourcesManager.DefaultAvatar;
            }
            TextWriter writer = new StringWriter();

            writer.Write("<span class='player'>");
            writer.Write("<img src='{0}' />", avatar);
            writer.Write("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>", ApplicationPath, id, name);
            writer.Write("</span>");

            State.SetFileCache(key, writer.ToString());

            return writer.ToString();
			//return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",ApplicationPath,id,name);
		}

        public static string PlayerSimpleUrl(string name, int id) {
            return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>", ApplicationPath, id, name);
        }

        internal static string GetPlayerAvatarCacheKey(int id)
        {
            string key = string.Format("Player-{0}.avatar.hml", id);
            return key;
        }

		public static string PrincipalUrl( string name, int id ){
			//return string.Format("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", ApplicationPath, id, name);
            string key = GetPrincipalAvatarCacheKey(id);
            if (State.HasFileCache(key)) {
                return State.GetFileCache(key);
            }
            string avatar = (string) Hql.ExecuteScalar("select p.Avatar from SpecializedPrincipal p where p.Id = :id", Hql.Param("id", id));
            if (string.IsNullOrEmpty(avatar)) {
                avatar = ResourcesManager.DefaultAvatar;
            }
            TextWriter writer = new StringWriter();

            writer.Write("<span class='player'>");
            writer.Write("<img src='{0}' />", avatar);
            writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", ApplicationPath, id, name);
            writer.Write("</span>");

            State.SetFileCache(key, writer.ToString());

            return writer.ToString();
		}

        internal static string GetPrincipalAvatarCacheKey(int id)
        {
            string key = string.Format("Principal-{0}.avatar.hml", id);
            return key;
        }

        internal static string WritePlayerWithAvatar(OrionsBelt.Core.PlayerStorage player)
        {
            return WritePlayerWithAvatar(player, true, true);
        }

        internal static string WritePlayerWithAvatar(OrionsBelt.Core.PlayerStorage player, bool writeLink, bool writeActivityStatus)
        {
            TextWriter writer = new StringWriter();

            writer.Write("<span class='player'>");
            writer.Write("<img src='{0}' />", GetAvatar(player));
            if( writeLink ) {
                writer.Write("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>", ApplicationPath, player.Id);
            }
            writer.Write("{0}", player.Name);
            if (writeLink) {
                writer.Write("</a>");
            }
            if (writeActivityStatus) {
                ActivityStatus status = PlayerUtils.GetStatus(player);
                writer.Write("<span class='activityStatus {0}'></span>", status);
            }
            writer.Write("</span>");

            return writer.ToString();
        }

        internal static string WritePrincipalWithAvatar(OrionsBelt.Core.Principal principal)
        {
            return WritePrincipalWithAvatar(principal.Id, principal.DisplayName, GetAvatar(principal));
        }

        public static string WritePrincipalWithAvatar(int principalId, string principalName, string avatar)
        {
            TextWriter writer = new StringWriter();

            writer.Write("<span class='player'>");
            writer.Write("<img src='{0}' />", avatar);
            writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", ApplicationPath, principalId, principalName);
            writer.Write("</span>");

            return writer.ToString();
        }

        public static string GetAvatar(OrionsBelt.Core.PlayerStorage player)
        {
            if (string.IsNullOrEmpty(player.Avatar)) {
                return ResourcesManager.DefaultAvatar;
            }
            return player.Avatar;
        }

        public static string GetAvatar(OrionsBelt.Core.Principal player)
        {
            if (string.IsNullOrEmpty(player.Avatar)) {
                return ResourcesManager.DefaultAvatar;
            }
            return player.Avatar;
        }

		#endregion

        #region Terms

        public static bool IsInTerms{
            get { return HttpContext.Current.Request.Url.AbsolutePath.Contains("Terms.aspx"); }
        }

        #endregion Terms

        #region Contacts

        public static bool IsInContacts{
            get { return HttpContext.Current.Request.Url.AbsolutePath.Contains("Contact.aspx"); }
        }

        public static void RedirectToContacts( string token ) {
            if (!IsInContacts){
				string url = string.Format(ApplicationPath + "Contact.aspx?message={0}", token);
                HttpContext.Current.Response.Redirect(url);
            }
        }

        #endregion Contacts

		#region Manual

		public static string GetManualLink(string section, IResourceInfo resource) {
			return string.Format("{0}Manual.aspx?path={2}/{1}.aspx", ApplicationPath, resource.Name, section);
		}

		#endregion Manual

        public static Control FindControl(Control source, string id)
        {
            //source.FindControl(id);
            if (source.ID == id)
            {
                return source;
            }
            foreach (Control control in source.Controls)
            {
                Control found = FindControl(control, id);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

		public static void GetLadderElemNumber()
	    {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                long init = persistance.ExecuteScalar("select count (*) from SpecializedPrincipal where  LadderActive = 1");
                State.SetMemory("elemNumber", (int)init);
            }
        }

        public static double GetDouble(string value)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                if (value.Contains(","))
                {
                    nfi.NumberDecimalSeparator = ",";
                }
                else
                {
                    nfi.NumberDecimalSeparator = ".";
                }
                return Convert.ToDouble(value, nfi);
            }catch(Exception)
            {
                return 0;
            }
        }

        #region Messages

        

        public static void DeletePM(int id)
        {
            using (IPrivateBoardPersistance persistance = Persistance.Instance.GetPrivateBoardPersistance())
            {
                persistance.Delete(id);
                persistance.Flush();
            }
        }

        public static void DeleteNecessity(int id)
        {
            using (INecessityPersistance persistance = Persistance.Instance.GetNecessityPersistance())
            {
                persistance.Delete(id);
                persistance.Flush();
            }
        }

        public static void DeleteAsset(int id)
        {
            using (IAssetPersistance persistance = Persistance.Instance.GetAssetPersistance())
            {
                persistance.Delete(id);
                persistance.Flush();
            }
        }

        public static void DeleteTask(int id)
        {
            using (ITaskPersistance persistance = Persistance.Instance.GetTaskPersistance())
            {
                Task task = persistance.SelectById(id)[0];
                task.Status = StatusEnum.Closed.ToString();
                persistance.Update(task);
                persistance.Flush();
            }
        }

        #endregion Messages
    };
}
