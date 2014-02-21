using System;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IBattleOwner {

		/// <summary>
		/// Id of the owner
		/// </summary>
        int Id { get; set;}

		/// <summary>
		/// String with the name of the owner
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Ranking of the owner
		/// </summary>
		int Ranking { get; }

		/// <summary>
		/// Last time the user was updated
		/// </summary>
		DateTime LastUpdate { get; }

		/// <summary>
		/// If the owner is on vacations
		/// </summary>
		bool IsOnVacations { get;}

		// <summary>
		/// Avatar of the player
		/// </summary>
		string Avatar { get; }

		// <summary>
		/// Player's Elo Ranking
		/// </summary>
		int Elo { get; }

		//If the owner is a bot
		bool IsBot { get;}

		//Bot Url
		string BotUrl { get;}

		//Bot Name
		string BotName { get; }

		//Bot Id
		int BotId { get; }

		//Has General
		bool HasGeneral { get; }

	}
}
