using System.Collections.Generic;
using OrionsBelt.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	
	internal abstract class InterpreterBase : IFactory {

		#region Factory Methods

		public object create( object args ) {
			Dictionary<string, object> arg = (Dictionary<string, object>) args;

			string info = arg["info"].ToString();
			BattleInfo battleInfo = (BattleInfo) arg["battleInfo"];
			return CreateInterpreter(info, battleInfo);
		}

		protected abstract object CreateInterpreter( string info, BattleInfo battleInfo );

		#endregion

		#region Fields 

		private string move;
		private BattleInfo battle;

		#endregion Fields

		#region Properties

		public string Move {
			get { return move; }
			set { move = value; }
		}

		public BattleInfo BattleInfo {
			get { return battle; }
			set { battle = value; }
		}

		#endregion Properties

		#region Protected

		/// <summary>
		/// Verifies if the quantities are ok
		/// </summary>
		/// <param name="element">Element with the information</param>
		/// <param name="quant">quantiry to verify</param>
		/// <returns></returns>
		protected static ResultItem ParseQuantity( IElement element, string quant ) {
			int q;
			if( !int.TryParse(quant, out q) ) {
				return new InvalidQuantity(quant, element.Unit.Name);
			}

			if( element.Quantity < q || q < 1 ) {
				return new InvalidUnitPositioning(element.Unit.Name, quant);
			}

			int min = (int) ( element.Quantity * 0.2 );

			if( q < min ) {
				return new MinimumMove(min.ToString(), element.Unit.Name, q.ToString());
			}

			int quantRest = ( element.Quantity - q );
			if( quantRest < min && quantRest != 0 ) {
				return new MinimumRest(quantRest.ToString(), element.Unit.Name, min.ToString());
			}

			return null;
		}

		#endregion

		#region Public

		/// <summary>
		/// Check the cost of the current move depending of the type of unit
		/// </summary>
		/// <returns>The movement cost of the unit</returns>
		public virtual int MoveCost() {
			return 1;
		}

		#endregion Public

		#region Abstract

		/// <summary>
		/// Checks if the move can be correctly made
		/// </summary>
		/// <returns>A result item with the result</returns>
		public abstract ResultItem CheckMove( );

		/// <summary>
		/// Executes the movement
		/// </summary>
		public abstract ResultItem Interpretate();

		#endregion Abstract

		#region Constructor

		public InterpreterBase() { }

		public InterpreterBase( string move, BattleInfo battleInfo ) {
			Move = move;
			BattleInfo = battleInfo;
		}

		#endregion Constructor
	}
}
