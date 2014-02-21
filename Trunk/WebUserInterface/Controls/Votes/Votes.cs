

using System;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Votes : IBackToStorage<VoteStorage> {
		#region Fields

		private int id;
		private readonly List<Vote> voteList = new List<Vote>();
		private static readonly char[] separator = new char[]{';'};
		private VoteStorage storage;
		private bool dirty = false;

		#endregion Fields

		#region Properties

		public int Id {
			get { return id; }
			set { id = value; }
		}

		#endregion Properties

		#region Static

		public static Votes GetCurrentPlayerVotes() {
			Dictionary<int, Votes> votes = GetVotes();
			int id = PlayerUtils.Current.Id;
			if (votes.ContainsKey(id)) {
				return votes[id];
			}
			Votes v = new Votes(id);
			votes.Add(id,v);
			return v;
		}

		public static Dictionary<int, Votes> GetVotes() {
			Dictionary<int, Votes> votes;
			if (!State.HasCache("Votes")) {
				votes = LoadVotes();
				State.SetCache("Votes", votes);
			} else {
				votes = (Dictionary<int, Votes>)State.GetCache("Votes");
			}
			return votes;
		}

		private static Dictionary<int, Votes> LoadVotes() {
			Dictionary<int, Votes> allVotes = new Dictionary<int, Votes>();
			IList<VoteStorage> votes = Hql.StatelessQuery<VoteStorage>("select v from SpecializedVoteStorage v");
			foreach (VoteStorage vote in votes) {
				Votes v = new Votes(vote);
				allVotes.Add(v.Id, v);
			}
			return allVotes;
		}

		#endregion Static

		#region IBackToStorage<VoteStorage> Members

		public VoteStorage Storage {
			get { return storage;}
			set {storage = value;}
		}

		public void UpdateStorage() {
			storage.OwnerId = Id;
			StringWriter writer = new StringWriter();
			foreach (Vote vote in voteList) {
				writer.Write(vote);
			}
			storage.Data = writer.ToString();
		}

		public void PrepareStorage() {
			if( storage==null) {
				storage = Persistance.Create<VoteStorage>();
			}
		}

		public void Touch() {
			dirty = true;
		}

		public bool IsDirty {
			get {return dirty;}
			set {dirty = value;
			}
		}

		#endregion IBackToStorage<VoteStorage> Members

		#region Public

		public void SetVote(string vote) {
			voteList.Add(new Vote(vote,DateTime.Now));
		}

		public Vote GetVote(string vote) {
			return voteList.Find(delegate(Vote v) { return v.Name == vote; });
		}

		public bool HasVoted(Vote foundVote) {
			if (foundVote != null) {
				DateTime date = foundVote.LastVote.AddDays(1);
				if (date > DateTime.Now) {
					return true;
				}
				voteList.Remove(foundVote);
			}
			return false;
		}

		public bool HasVoted(string vote) {
			Vote foundVote = voteList.Find(delegate(Vote v) { return v.Name == vote; });
			return HasVoted(foundVote);
		}

		public void Save() {
			using (IVoteStoragePersistance persistance = Persistance.Instance.GetVoteStoragePersistance()) {
				PrepareStorage();
				UpdateStorage();
				persistance.Update(Storage);
			}
		}

		#endregion Public

		#region Constructor

		public Votes(int id) {
			Id = id;
		}

		public Votes(VoteStorage voteStorage) {
			Id = voteStorage.OwnerId;
			string[] data = voteStorage.Data.Split(separator,StringSplitOptions.RemoveEmptyEntries);
			foreach (string vote in data) {
				Vote v = new Vote(vote);
				voteList.Add(v);
			}
			Storage = voteStorage;
		}

		#endregion Constructor

	}
}
