namespace OrionsBelt.RulesCore.Interfaces {

	public interface IFleetElement {
		/// <summary>
		/// Object that represents the unit
		/// </summary>
		IUnitInfo UnitInfo { get; set; }

		/// <summary>
		/// Name of the unit inside the element
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Quantity of element
		/// </summary>
		int Quantity { get; set; }
	}
}