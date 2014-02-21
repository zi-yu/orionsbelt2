using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Collections;

namespace OrionsBelt.WebUserInterface.Controls {
	public class VoteControl : Control{
		#region Fields

		private static Random random = new Random((int)DateTime.Now.Ticks);
		private delegate string Reward();
		private static readonly Dictionary<string, Reward> rewards = new Dictionary<string, Reward>();
		private delegate void CommitRewards();
		private static readonly Dictionary<string, CommitRewards> commitRewards = new Dictionary<string, CommitRewards>();
		
		#endregion Fields

		#region Delegates

		private static string IntrinsicReward() {
			IResourceInfo resource = GetRaceResource();
			return string.Format("50 {0}", ResourcesManager.GetResourceSmallImageHtml(resource));
		}

		private static string RareReward() {
			IResourceInfo resource = GetRareResource();
			return string.Format("25 {0}", ResourcesManager.GetResourceSmallImageHtml(resource));
		}

		private static void IntrinsicCommitReward() {
			IResourceInfo resource = GetRaceResource();
			PlayerUtils.Current.AddQuantity(resource, 50);
			GameEngine.Persist(PlayerUtils.Current, false, false);
		}

		private static void RareCommitReward() {
			IResourceInfo resource = GetRareResource();
			PlayerUtils.Current.AddQuantity(resource, 25);
			GameEngine.Persist(PlayerUtils.Current,false,false);
		}

		#endregion Delegates

		#region Private

		public static IResourceInfo GetRaceResource() {
			Race race = PlayerUtils.Current.RaceInfo.Race;
			string key = "VoteRaceResource" + race;
			if (State.HasCache(key)) {
				return (IResourceInfo)State.GetCache(key);
			}
			IResourceInfo resource = GetResource(false);
			State.SetCache(key, resource);
			return resource;
		}

		public static IResourceInfo GetRareResource() {
			if (State.HasCache("VoteRareResource")) {
				return (IResourceInfo)State.GetCache("VoteRareResource");
			}
			IResourceInfo resource = GetResource(true);
			State.SetCache("VoteRareResource", resource);
			return resource;
		} 

		public static IResourceInfo GetResource(bool rare) {
			List<IResourceInfo> info = RulesUtils.GetInstrinsicResources(PlayerUtils.Current).FindAll(delegate(IResourceInfo resource) { return resource.IsRare == rare; });
			return info[random.Next(0, info.Count)];
		} 

		public static List<VoteReferral> GetVotes() {
			List<VoteReferral> votes;
			if (!State.HasCache("VoteReferral")) {
				votes = LoadVotes();
				State.SetCache("VoteReferral", votes);
			} else {
				votes = (List<VoteReferral>)State.GetCache("VoteReferral");
			}
			return votes;
		}

		private static List<VoteReferral> LoadVotes() {
			return (List<VoteReferral>)Hql.StatelessQuery<VoteReferral>("select v from SpecializedVoteReferral v order by v.VoteOrder asc");
		}

		private static void WriteTitle(HtmlTextWriter writer) {
			writer.Write("<tr>");
			writer.Write("<th>{0}</th>",LanguageManager.Instance.Get("TopList"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("TimeLeftForNextVote"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Reward"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("HasVotedToday"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("CastVote"));
			writer.Write("</tr>");
		}

		private static void WriteVote(HtmlTextWriter writer, VoteReferral vote, Votes playerVotes) {
			writer.Write("<tr>");
			bool hasVotedToday = HasVotedToday(vote, playerVotes);

			writer.Write("<td>{0}</td>", GetVoteImage(hasVotedToday, vote));
			
			Vote v = playerVotes.GetVote(vote.ShortName);
			if (hasVotedToday) {
			    DateTime addedDate = v.LastVote.AddDays(1);
			    TimeSpan t = addedDate - DateTime.Now;
				writer.Write("<td>{0}</td>", TimeFormatter.GetFormattedTime(t));	
			}else {
				writer.Write("<td></td>");	
			}
			
			writer.Write("<td>{0}</td>", GetReward(vote) );
			writer.Write("<td>{0}</td>", GetHasVotedToday(hasVotedToday, vote));
			writer.Write("<td>{0}</td>", GetCastVote(hasVotedToday, vote));
			writer.Write("</tr>");
		}

		private static string GetVoteImage(bool hasVotedToday, VoteReferral vote) {
			if (!hasVotedToday) {
				return string.Format("<a href='VotePage.aspx?vote={0}' onclick='Site.changeCastState(\"{0}\")'><img class='topList' src='{1}' alt='{2}' title='{2}'/></a>", vote.ShortName, vote.ImageUrl, vote.Name);
			}
			return string.Format("<img class='topList' src='{0}' alt='{1}' title='{1}'/>", vote.ImageUrl, vote.Name);;
		}

		private static string GetCastVote(bool hasVotedToday, VoteReferral vote) {
			if( !hasVotedToday ) {
				return string.Format("<a id='{0}CastVote' href='javascript:Site.changeCastState(\"{0}\");'>{1}</a>", vote.ShortName, LanguageManager.Instance.Get("CastVote"));
			}
			return string.Empty;
		}

		private static string GetHasVotedToday(bool hasVotedToday, VoteReferral vote) {
			if (hasVotedToday) {
				return string.Format("<span class='red'>{0}</span>", LanguageManager.Instance.Get("Yes"));
			}
			return string.Format("<span id='{1}HasVoted' class='green'>{0}</span>", LanguageManager.Instance.Get("No"), vote.ShortName);
		}

		private static bool HasVotedToday(VoteReferral vote, Votes playerVotes) {
			return playerVotes.HasVoted(vote.ShortName);
		}

		private static string GetReward(VoteReferral vote) {
			return rewards[vote.Reward]();
		}

		#endregion Private

		#region Cast Vote

		private static void CastVote(string vote) {
			Votes v = Votes.GetCurrentPlayerVotes();
			if (!v.HasVoted(vote)) {
				v.SetVote(vote);
				v.Save();
				VoteReferral voteReferral = GetVoteReferral(vote);
				if (voteReferral != null) {
					UpdateVoteReferral(voteReferral);
					UpdatePlayer(voteReferral);
					Persistance.Flush();
					HttpContext.Current.Response.Redirect(voteReferral.Url);
				}
			} else {
				ErrorBoard.AddLocalizedMessage("CannotCast");
			}
		}

		private static void UpdatePlayer(VoteReferral voteReferral) {
			commitRewards[voteReferral.Reward]();
			if( HasVotedInAll() && !HasReceivedPriceLess24Hours() ) {
				CreditsUtil.VotingReward(Utils.Principal,20);
			}
		}

        private static bool HasReceivedPriceLess24Hours(){
            IList<Transaction> transactions = Hql.Query<Transaction>("select t from SpecializedTransaction t where t.TransactionContext = 'VotingPrize' and t.IdentifierGain = :id Order By t.CreatedDate desc", Hql.Param("id", Utils.Principal.Id));
            if (transactions.Count == 0){
                return false;
            }
            DateTime t = transactions[0].CreatedDate.AddDays(1);
            return t > DateTime.Now;
        }

		private static bool HasVotedInAll() {
			Votes playerVotes = Votes.GetCurrentPlayerVotes();
			foreach (VoteReferral vote in GetVotes()) {
				if (!HasVotedToday(vote, playerVotes)) {
					return false;
				}
			}
			return true;
		}

		private static void UpdateVoteReferral(VoteReferral voteReferral) {
			using (IVoteReferralPersistance persistance = Persistance.Instance.GetVoteReferralPersistance()) {
				voteReferral.ClickCount += 1;
				persistance.Update(voteReferral);
			}
		}

		private static VoteReferral GetVoteReferral(string vote) {
			List<VoteReferral> votes = GetVotes();
			return votes.Find(delegate(VoteReferral voteReferral) { return voteReferral.ShortName.Equals(vote); });
		}

		#endregion Cast Vote

		#region Controls Events

		protected override void OnInit(EventArgs e) {
			string vote = HttpContext.Current.Request.QueryString["vote"];
			if(!string.IsNullOrEmpty(vote)) {
				CastVote(vote);
			}
		}
		
		protected override void Render(HtmlTextWriter writer) {
			IList<VoteReferral> votes = GetVotes();
			Votes playerVotes = Votes.GetCurrentPlayerVotes();
			writer.Write("<table id='voteTable' class='table'>");
			WriteTitle(writer);
			foreach (VoteReferral vote in votes) {
				WriteVote(writer, vote, playerVotes);
			}
			writer.Write("</table>");
		}

		#endregion Controls Events

		#region Constructor

		static VoteControl() {
			rewards["Intrinsic"] = IntrinsicReward;
			rewards["Rare"] = RareReward;
			commitRewards["Intrinsic"] = IntrinsicCommitReward;
			commitRewards["Rare"] = RareCommitReward;
			
		}

		#endregion Constructor


	}
}
