using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IResourceQuantity {
		IResourceInfo Resource { get; }
		int Quantity { get; }
	}
}