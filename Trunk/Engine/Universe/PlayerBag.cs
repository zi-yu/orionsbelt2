using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using System.Web;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Player related utilities
    /// </summary>
    internal class PlayerBag {

		#region Fields

		private readonly Dictionary<int,IPlayer> players = new Dictionary<int, IPlayer>();
        private static PlayerBag instance = new PlayerBag();

		#endregion Fields

		#region Properties

    	public static PlayerBag Instance {
    		get {
                if (HttpContext.Current == null) {
                    return instance;
                }
    			if( !State.HasItems("PlayerBag") ) {
    				State.SetItems("PlayerBag",new PlayerBag());
    			}
				return (PlayerBag)State.GetItems("PlayerBag");
    		}
    	}

		#endregion

		#region Public

		/// <summary>
		/// if the bag already has the player
		/// </summary>
		/// <param name="id">Id of the player</param>
		public bool HasPlayer(int id) {
			return players.ContainsKey(id);
		}

    	/// <summary>
		/// Adds a new player to the bag if he doesn't have been added already
		/// </summary>
		/// <param name="player">Player to add</param>
		public void AddPlayer( IPlayer player ) {
			if( !players.ContainsKey(player.Id) ) {
				players.Add(player.Id,player);
			}
		}

		/// <summary>
		/// Gets the player with the passed id
		/// </summary>
		/// <param name="id">Id of the player to return</param>
		public IPlayer GetPlayer(int id) {
			if (players.ContainsKey(id)) {
				return players[id];
			}
			throw new EngineException("Player with the id '{0}' should exist in the bag. Use PlayerUtils.HasPlayer to check if exists before getting him",id);
		}
		
		#endregion Public
    };
}
