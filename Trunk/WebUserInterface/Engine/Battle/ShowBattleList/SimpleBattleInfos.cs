using System.Collections;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class SimpleBattleInfos {

		#region Fields

        private readonly Dictionary<BattleMode, Mode> simpleBattleInfos = new Dictionary<BattleMode, Mode>();
		private static string query = @"select b from SpecializedBattle b inner join b.PlayerInformationNHibernate pi where b.HasEnded = :ended and ( ( b.BattleMode = 'Friendly' and pi.Owner = :principal ) or ( b.BattleMode = 'Tournament' and pi.Owner = :principal ) or ( b.BattleMode = 'Campaign' and pi.Owner = :principal ) or ( b.BattleMode = 'Battle' and pi.Owner = :player ) or ( b.BattleMode = 'Arena' and pi.Owner = :player ))";

        public static string BaseQuery {
            get { return query;  }
        }

	    #endregion Fields

        #region Private

		/// <summary>
		/// Adds a new SimpleBattleInfo object into the dictionary
		/// </summary>
		/// <param name="battle">battle element with the information of the SimpleBattleInfo</param>
		private void AddSimpleBattleInfo( Battle battle ) {
            SimpleBattleInfo simpleBattleInfo = new SimpleBattleInfo(battle);
		    AddMode(simpleBattleInfo);
		}

        private void AddMode(SimpleBattleInfo simpleBattleInfo) {
            BattleMode m = simpleBattleInfo.BattleMode;
            if( !simpleBattleInfos.ContainsKey(m) ) {
                simpleBattleInfos.Add( m, new Mode( m ) );
            }
            simpleBattleInfos[simpleBattleInfo.BattleMode].AddSimpleBattleInfo(simpleBattleInfo);
        }

		public static string GetWhere(IList<Battle> battles) {
			if( battles.Count > 0 ) {
				StringWriter writer = new StringWriter();
				writer.Write("where b.Id = {0}", battles[0].Id);

				for (int i = 1; i < battles.Count; ++i ) {
					writer.Write(" or b.Id = {0}", battles[i].Id);
				}
				return writer.ToString();
			}
			return string.Empty;
		}

		private static string[] GetHql() {
			return GetHql(string.Empty);
		}

		public static string[] GetHql(string where) {
			string[] hql = new string[2];
			hql[0] = string.Format("select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate {0} order by b.Id desc",where);
            hql[1] = string.Format("select b from SpecializedBattle b inner join fetch b.TimedActionNHibernate {0} order by b.Id desc", where);
			return hql;
		}

		private void LoadAllBattles(string[] hql) {
			using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
				IList battles = persistance.MultiQuery(hql, new Dictionary<string, object>());
				IList<Battle> allBattles = Hql.Unify(SectorUtils.ConvertToList<Battle>((IEnumerable)battles[0]));
				foreach (Battle battle in allBattles) {
                    if (battle.TimedAction != null && battle.TimedAction.Count > 0) {
                        if (battle.TimedAction[0].EndTick > (Clock.Instance.Tick + 144)) {
                            using (ITimedActionStoragePersistance pt = Persistance.Instance.GetTimedActionStoragePersistance()) {
                                pt.StartTransaction();
                                battle.TimedAction[0].EndTick = Clock.Instance.Tick + 144;
                                pt.Update(battle.TimedAction[0]);
                                pt.CommitTransaction();
                            }
                        }
                    }
					AddSimpleBattleInfo(battle);
				}
			}
		}

		#endregion Private
		
		#region Public

		/// <summary>
		/// Load current player battlkes
		/// </summary>
		public void LoadBattles() {
			Dictionary<string,object> param = new Dictionary<string, object>();
			param["player"] = PlayerUtils.Current.Id;
			param["principal"] = Utils.Principal.Id;
            param["ended"] = false;
			IList<Battle> battles = Hql.Query<Battle>(query,param);
			if (battles.Count > 0){
				LoadAllBattles(GetHql(GetWhere(battles)));
			}
		}

		/// <summary>
		/// Load All the battles
		/// </summary>
        public void LoadAllBattles() {
        	LoadAllBattles(GetHql());
        }

        public Mode GetBattleMode( BattleMode mode ) {
            if( simpleBattleInfos.ContainsKey(mode)) {
                return simpleBattleInfos[mode];
            }
            return null;
        }

		#endregion Public
		
	}
}
