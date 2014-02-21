using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {
    public interface IUltimateWeaponArgs {
    	IPlayer Owner { get; }
		SectorCoordinate Coordinate { get; }
	}
}
