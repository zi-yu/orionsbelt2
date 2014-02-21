using System.Collections.Generic;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IInitialContainer {

		/// <summary>
		/// List of the initial units of the container
		/// </summary>
		List<IElement> InitialUnits { get; set; }

		/// <summary>
		/// Verifies if the container still has units
		/// (only valid during the positioning)
		/// </summary>
		bool HasUnits { get; }


		/// <summary>
		/// Gets the element that has the unit with the specified code
		/// </summary>
		/// <param name="code">Code of the Unit</param>
		IElement GetElement(string code);

		/// <summary>
		/// Adds and element to the initial container
		/// </summary>
		/// <param name="unit">Unit to add</param>
		/// <param name="quantity">Quantity to add</param>
		void AddUnit( IUnitInfo unit, int quantity );

		/// <summary>
		/// Removes from the initial container the specified quantity. If the quantity 
		/// is Zero the element is removed from the container
		/// </summary>
		/// <param name="element">Element to remove</param>
		/// <param name="quantity">Quanity</param>
		/// <returns>
		/// In case the quantity to remove is bigger than the quantity of the element
		/// then a InvalidUnitPositioning result is returned. Otherside null is returned
		/// </returns>
		ResultItem Remove(IElement element, int quantity);

	}
}
