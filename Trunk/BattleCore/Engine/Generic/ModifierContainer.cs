using System.Collections.Generic;

namespace OrionsBelt.BattleCore {
	internal class ModifierContainer {

		#region Fields

		private readonly List<Modifier> modifiers = new List<Modifier>();

		#endregion Fields

		#region Public

		/// <summary>
		/// Adds a new modifier
		/// </summary>
		/// <param name="modifier">Modifier to add</param>
		public void Add( Modifier modifier) {
			modifiers.Add(modifier);
		}

		/// <summary>
		/// Adds a new modifier with the passed information 
		/// </summary>
		/// <param name="min">Minimum Value</param>
		/// <param name="max">Maximum Value</param>
		/// <param name="value">Value of the offset</param>
		public void Add( int min, int max, double value ) {
			modifiers.Add(new Modifier(min, max, value));
		}

		/// <summary>
		/// Adds a new modifier with the passed information 
		/// </summary>
		/// <param name="min">Minimum Value</param>
		/// <param name="value">Value of the offset</param>
		public void Add( int min, double value ) {
			modifiers.Add(new Modifier(min, -1, value));
		}

		public double GetModifier( int value ) {
			Modifier m = modifiers.Find(delegate(Modifier modifier) {
				bool max = modifier.Max == -1 ? true : modifier.Max >= value;
				return modifier.Min <= value && max;
			});

			if( null == m ) {
				return 0;
			}

			return m.Value;
		}

		#endregion Public

	}
}
