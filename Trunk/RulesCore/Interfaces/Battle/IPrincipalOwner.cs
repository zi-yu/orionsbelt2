using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IPrincipalOwner : IBattleOwner {
		Principal Principal {get; }
	}
}
