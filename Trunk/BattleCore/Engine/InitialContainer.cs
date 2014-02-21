using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class InitialContainer: IInitialContainer {

		#region Fields

		private BattlePlayer owner;
		private List<IElement> initialUnits = new List<IElement>();
		
		#endregion Fields

		#region Properties

		public List<IElement> InitialUnits {
			get { return initialUnits; }
			set { initialUnits = value; }
		}

		public bool HasUnits {
			get { return initialUnits.Count > 0; }
		}

		public BattlePlayer Owner {
			get { return owner; }
			set { owner = value; }
		}

		#endregion Properties

		#region Private

		private void ParseUnits( string units ) {
			string[] splittedUnits = units.Split(';');
			foreach( string splittedUnit in splittedUnits ) {
				if( splittedUnit.Length == 0 ) {
					continue;
				}
				IElement element = ElementParser.ParseInitialElement(splittedUnit);
				element.Owner = Owner;
				initialUnits.Add( element );
			}
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Gets the element that has the unit with the specified code
		/// </summary>
		/// <param name="code">Code of the Unit</param>
		public IElement GetElement( string code ) {
			return InitialUnits.Find(
				delegate( IElement element ) {
					return string.Compare(element.Unit.Code, code) == 0;
				}
			);
		}

		/// <summary>
		/// Adds and element to the initial container
		/// </summary>
		/// <param name="unit">Unit to add</param>
		/// <param name="quantity">Quantity to add</param>
		public void AddUnit( IUnitInfo unit, int quantity ) {
			initialUnits.Add(new Element(unit, quantity));
		}

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
		public ResultItem Remove( IElement element, int quantity ) {
			IElement e = GetElement(element.Unit.Code);
			if( e != null) {
				e.Quantity -= quantity;
				if( e.Quantity == 0 ) {
					initialUnits.Remove(e);
					return null;
				}
				if( e.Quantity > 0 ) {
					return null;
				}
			}
			
			return new InvalidUnitPositioning(element.Unit.Name,quantity.ToString());
		}

		#endregion Public

		#region Constructor

		public InitialContainer( PlayerBattleInformation playerInformation, BattlePlayer owner) {
			Owner = owner;
			ParseUnits(playerInformation.InitialContainer);
		}

		#endregion Constructor

	}
}
