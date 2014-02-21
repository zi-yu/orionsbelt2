using System;
using System.Collections.Generic;
using System.IO;
using BotHandler.Engine;

namespace BotHandler {
	public class FiringSquadDeploy : Deploy {

		#region Fields

		protected static FiringSquadDeploy instance = new FiringSquadDeploy();

		#endregion Fields

		#region Properties

		public static Deploy Instance {
			get { return instance; }
		}

		#endregion Properties

		#region Util Classes

		private class UnitPos {
			public Unit Unit;
			public int X;
			public int Y;
			public int Quantity;
		};

		#endregion Util Classes

		#region Private

		private static void WriteBackRow(TextWriter writer, Battle battle, List<Unit> backRow) {
			WriteRow(writer, battle, backRow, 8);
		}

		private static void WriteFrontRow(TextWriter writer, Battle battle, List<Unit> frontRow) {
			WriteRow(writer, battle, frontRow, 7);
		}

		private static void WriteRow(TextWriter writer, Battle battle, List<Unit> row, int y) {
			if (row.Count == 0) {
				return;
			}
			int totalUnits = row.Count;
			int x = 1;
			List<UnitPos> final = new List<UnitPos>();

			while (x < 9) {

				bool addedQuantity = false;
				foreach (Unit unit in row) {
					if (unit.Quantity == 0) {
						continue;
					}
					double q = unit.Quantity;
					int quantity = Convert.ToInt32(Math.Floor(q / 8));
					if (quantity < 1 && unit.Quantity >= 1) {
						quantity = 1;
					}
					unit.Quantity -= quantity;

					UnitPos pos = new UnitPos();
					pos.Unit = unit;
					pos.X = x;
					pos.Y = y;
					pos.Quantity = quantity;
					addedQuantity = true;

					final.Add(pos);

					if (++x == 9) {
						break;
					}
				}
				if (!addedQuantity) {
					break;
				}
			}

			int resolvedUnits = 0;
			while (resolvedUnits != totalUnits) {
				bool doneSomething = false;
				foreach (UnitPos pos in final) {
					if (pos.Unit.Quantity == 0) {
						continue;
					}
					int quantity = 1;
					pos.Unit.Quantity -= quantity;
					pos.Quantity += quantity;
					doneSomething = true;
					if (pos.Unit.Quantity == 0) {
						++resolvedUnits;
					}
				}
				if (!doneSomething) {
					break;
				}
			}

			foreach (UnitPos pos in final) {
				writer.Write("p:{0}-{1}_{2}-{3};", pos.Unit.Code, pos.Y, pos.X, pos.Quantity);
			}
		}

		private static void SetFrontAndBackRowUnits(Battle battle, List<Unit> frontRow, List<Unit> backRow) {
			foreach (Unit unit in battle.Units) {
				if (unit.Info.Range >= 4) {
					frontRow.Add(unit);
				} else {
					backRow.Add(unit);
				}
			}
		}

		#endregion Private

		#region Public

		public static string GetFiringSquadDeploy(Battle battle) {
			Console.WriteLine("#######################################");
			Console.WriteLine("\tBattle {0} | {1} vs {2} | Turn: {3}", battle.Id, battle.Players[1].Name, battle.Players[0].Name, battle.Turn);
			Console.WriteLine("#######################################");

			List<Unit> frontRow = new List<Unit>();
			List<Unit> backRow = new List<Unit>();

			SetFrontAndBackRowUnits(battle, frontRow, backRow);

			TextWriter writer = new StringWriter();

			WriteFrontRow(writer, battle, frontRow);
			WriteBackRow(writer, battle, backRow);
			return writer.ToString();
		}

		public override void MakeDeploy(Battle battle) {
			string deploy = GetFiringSquadDeploy(battle);

			MakeDeploy(battle, deploy);
		}

		#endregion Public

		#region Constructor

		public FiringSquadDeploy() {
			botName = "FiringSquad";
		}

		#endregion Constructor
	}
}
