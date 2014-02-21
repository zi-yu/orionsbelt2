using System;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	public class UltimateUnit : IUltimateUnit {

		#region Fields

		private readonly IElement ultimateUnit;
		private readonly char[] separator = new char[] { '-' };

		#endregion Fields

		#region Properties

		public IElement Element{
			get { return ultimateUnit; }
		}

		public string Name {
			get { return ultimateUnit.Unit.Name; } 
		}

		public string Code {
			get { return ultimateUnit.Unit.Code; }
		}
				
		#endregion Properties

		#region Private

		private int GetCoolDown(string[] unitSplitted){
			if (unitSplitted.Length > 1){
				return int.Parse(unitSplitted[1]);
			}
			return ultimateUnit.Unit.CoolDown;
		}

		private int GetDefense(string[] unitSplitted){
			if (unitSplitted.Length > 1){
				return int.Parse(unitSplitted[2]);
			}

			return ultimateUnit.Unit.Defense;
		}

		#endregion Private

		#region Public

		public override string ToString(){
			return string.Format("{0}-{1}-{2}", ultimateUnit.Unit.Code, ultimateUnit.Cooldown, ultimateUnit.RemainingDefense);
		}

		#endregion Public

		#region Constructor

		public UltimateUnit(string unit, IBattlePlayer owner, IBattleInfo battleInfo) {
			string[] unitSplitted = unit.Split(separator,StringSplitOptions.RemoveEmptyEntries);
			IUnitInfo u = OrionsBelt.BattleCore.Unit.Create(unitSplitted[0]);
			IBattleCoordinate coordinate = owner.PositionConverter.ConvertCoordinateToSpecific(new BattleCoordinate(9, 9));

			ultimateUnit = new Element(u, 1, coordinate, owner);
			ultimateUnit.Cooldown = GetCoolDown(unitSplitted);
			if (ultimateUnit.Cooldown > 0 ) {
				ultimateUnit.AddEffect(new CoolDown(ultimateUnit, ultimateUnit.Cooldown));	
			}

			ultimateUnit.RemainingDefense = GetDefense(unitSplitted);
			ultimateUnit.Position = owner.PositionConverter.ConvertPositionToSpecific(PositionType.N);

			battleInfo.BattleStatistics.AddPlayer(owner);
			battleInfo.BattleStatistics.Add(owner, ultimateUnit);

			

		}

		#endregion Constructor

	}
}
