using System;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Enum;

namespace BotHandler.Engine {
    public class Bot001Deploy : Deploy{

		#region Fields

		protected static Deploy instance = new Bot001Deploy();
        private static readonly Random random = new Random(DateTime.Now.Millisecond);
        
		#endregion Fields

		#region Properties

		public static Deploy Instance {
			get { return instance; }
		}

		#endregion Properties

        #region Private
        
        private static IEnumerable<Unit> GetUnits(Battle battle, UnitCategory category){
            foreach (Unit unit in battle.Units) {
                if( unit.Info.UnitCategory == category) {
                    yield return unit; 
                }
            }
        }

        private static void DeployLight(Dictionary<Coordinate, Unit> deployBoard, Battle battle){
            List<Unit> units = battle.Units.FindAll(delegate(Unit u) { return u.Info.UnitCategory == UnitCategory.Light; });
            if( units.Count > 0 ) {
                int available = 16-deployBoard.Count;
                int prUnit = available/units.Count;
			    foreach (Unit unit in units) {
				    int q = unit.Quantity;
				    int qpersquare = unit.Quantity / prUnit;
				    if (qpersquare == 0) {
					    qpersquare = q;
				    }
				    for (int i = 0; i < prUnit; ++i) {
					    if( q == 0) {
						    break;
					    }
					    Unit n;
					    if (i != prUnit - 1) {
						    n = new Unit(unit, qpersquare);
						    q -= qpersquare;
					    } else {
						    n = new Unit(unit, q);
					    }
					    Coordinate c = new Coordinate(8, 1);
					    bool notDeployed = true;
					    while (notDeployed) {
						    c.X = GetRandom(7, 9);
						    c.Y = GetRandom(1, 9);
						    notDeployed = Insert(deployBoard, c, n);
					    }
					    --available;
				    }
			    }
            }
        }

		private static short GetRandom(int x, int y) {
			return (short) random.Next(x, y);
		}

        private static void DeployMedium(Dictionary<Coordinate, Unit> deployBoard, Battle battle){
            foreach (Unit unit in GetUnits(battle, UnitCategory.Medium)){
                short x = (short)(unit.Info.Defense > 1999 ? 7 : 8);  
                Coordinate c = new Coordinate(x, 1);
                bool notDeployed = true;
                while (notDeployed) {
					c.Y = GetRandom(1, 9);
                    notDeployed = Insert(deployBoard,c,unit);
                }
            }
        }

        private static void DeployHeavy(Dictionary<Coordinate, Unit> deployBoard, Battle battle){
            foreach (Unit unit in GetUnits(battle, UnitCategory.Heavy)){
                short x = (short)(unit.Info.Defense > 1999 ? 7 : 8);
                int q = unit.Quantity;
                for (int i = 0; i < 2; ++i ) {
					if(q==0) {
						break;
					}
                    Unit n;
                    if( i == 0) {
                    	int quant = q/2;
						if(quant == 0) {
							n = new Unit(unit, q);
							q = 0;
						}else {
							n = new Unit(unit, quant);
							q -= q / 2;
						}
                    }else {
                        n = new Unit(unit, q);
                    }
                    Coordinate c = new Coordinate(x, 1);
                    bool notDeployed = true;
                    while (notDeployed) {
						c.Y = GetRandom(1, 9);
                        notDeployed = Insert(deployBoard,c,n);
                    }
                }
            }
        }

        private static void DeploySpecial(Dictionary<Coordinate, Unit> deployBoard, Battle battle){
            
            foreach (Unit unit in GetUnits(battle, UnitCategory.Special)){
                Coordinate c = new Coordinate(8, 1);
                bool notDeployed = true;
                while (notDeployed) {
					c.Y = GetRandom(1, 9);
                    notDeployed = Insert(deployBoard,c,unit);
                }
            }
        }

        private static bool Insert(Dictionary<Coordinate, Unit> deployBoard,Coordinate c, Unit unit){
            if( !deployBoard.ContainsKey(c) ) {
                deployBoard[c] = unit;
                return false;   
            }
            return true;
        }

        #endregion Private

        #region Public

        public override void MakeDeploy(Battle battle) {
            Dictionary<Coordinate, Unit> deployBoard = new Dictionary<Coordinate,Unit>();

            DeploySpecial(deployBoard, battle);
            DeployHeavy(deployBoard, battle);
            DeployMedium(deployBoard, battle);
            DeployLight(deployBoard, battle);

            StringWriter writer = new StringWriter();
            foreach (KeyValuePair<Coordinate, Unit> pair in deployBoard) {
                writer.Write("p:{0}-{1}_{2}-{3};", pair.Value.Info.Code, pair.Key.X, pair.Key.Y, pair.Value.Quantity);
            }
            //StringWriter writer = new StringWriter();
            //int x = 1;
            //int y = 8;
            //foreach (Unit unit in battle.Units) {
            //    writer.Write("p:{0}-{1}_{2}-{3};", unit.Code, y,x, unit.Quantity);
            //    if(x == 8) {
            //        x = 1;
            //        y = 7;
            //    }else {
            //        ++x;
            //    }
            //}
            MakeDeploy(battle, writer.ToString() );
		}

		#endregion Public

        #region Constructor

        protected Bot001Deploy() {
        	botName = "Bot001";
        }
        
        #endregion Constructor

    }
}
