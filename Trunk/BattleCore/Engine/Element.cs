using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal class Element: IElement  {

		#region Fields

		private PositionType position;
		private IBattleCoordinate coordinate;
		private IUnitInfo unit;
		private int quantity;
		private int originalQuantity;
		private int remainingDefense;
		private IBattlePlayer owner;
		private Dictionary<string, List<IEffect>> effects = new Dictionary<string, List<IEffect>>();
		private bool canBeMoved = true;
		private bool canUseSpecialAbilities = true;
		private int coolDown = 0;
		
		#endregion Fields

		#region Private

		/// <summary>
		/// Adds an new effect to this element
		/// </summary>
		/// <param name="effect">Effect to add</param>
		private void AddNewEffect( IEffect effect ) {
			List<IEffect> effectList = new List<IEffect>();
			effectList.Add(effect);

			Effects[effect.Name] = effectList;
		}

		/// <summary>
		/// Renews an new effect to this element
		/// </summary>
		/// <param name="effect">Effect to renew</param>
		private void RenewEffect( IEffect effect ) {
			if( effect.Cumulative ) {
				Effects[effect.Name].Add(effect);
			} else {
				List<IEffect> effectsList = Effects[effect.Name];
				effectsList.Clear();
				effectsList.Add(effect);
			}
		}

		/// <summary>
		/// Resolves the special effects of a unit
		/// </summary>
		/// <param name="moves">List of moves</param>
		/// <param name="battleInfo">Battle Information</param>
		/// <param name="unit">Unit to resolve</param>
		/// <param name="target">Target Element</param>
		private static void ResolveSpecialMove( List<ISpecialMove> moves, IBattleInfo battleInfo, IElement unit, IElement target ) {
			foreach( ISpecialMove specialMove in moves ) {
				specialMove.ResolveMove(battleInfo, unit, target);
			}
		}

		/// <summary>
		/// Converts the effects into it's string representation
		/// </summary>
		/// <returns>string representation of the effects</returns>
		private string EffectsToString() {
			StringBuilder builder = new StringBuilder();
			foreach( KeyValuePair<string, List<IEffect>> pair in Effects ) {
				foreach ( IEffect e in pair.Value ) {
					builder.AppendFormat("{0}$", e);
				}
			}
			string effectsStr = builder.ToString();
			if( effectsStr.Length > 0 ) {
				effectsStr = effectsStr.Substring(0, effectsStr.Length - 1);
			}
			return effectsStr;
		}

		#endregion Private

		#region IElement Members

		/// <summary>
		/// Cuurent position of the element: N,S,E,W
		/// </summary>
		public PositionType Position {
			get { return position; }
			set { position = value; }
		}

		/// <summary>	
		/// Coordinate of this element in the game board
		/// </summary>
		public IBattleCoordinate Coordinate {
			get { return coordinate; }
			set { coordinate = value; }
		}

		/// <summary>
		/// Object that represents the unit in this element
		/// </summary>
		public IUnitInfo Unit {
			get { return unit; }
			set { unit = value; }
		}

		/// <summary>
		/// Quantity of units in this element
		/// </summary>
		public int Quantity {
			get { return quantity; }
			set { quantity = value; }
		}

		/// <summary>
		/// Original Quantity of units in this element
		/// </summary>
		public int OriginalQuantity {
			get { return originalQuantity; }
			set { originalQuantity = value; }
		}

		/// <summary>
		/// Remaining defense of the last unit in the element
		/// </summary>
		public int RemainingDefense {
			get { return remainingDefense; }
			set { remainingDefense = value; }
		}

		/// <summary>
		/// Gets the owner of this element
		/// </summary>
		public IBattlePlayer Owner {
			get { return owner; }
			set { owner = value; }
		}

		/// <summary>
		/// Indicates if this element can be moved
		/// </summary>
		public bool CanBeMoved {
			get{ return canBeMoved; }
			set{ canBeMoved = value; }
		}

		/// <summary>
		/// Indicates if this element can use special Abilities
		/// </summary>
		public bool CanUseSpecialAbilities {
			get { return canUseSpecialAbilities; }
			set { canUseSpecialAbilities = value; }
		}

		/// <summary>
		/// Returns true if the element has effects
		/// </summary>
		public bool HasEffects {
			get{ return Effects.Count > 0; }
		}

		public Dictionary<string, List<IEffect>> Effects {
			get { return effects; }
		}

		// <summary>
		/// Unit Cooldown
		/// </summary>
		public int Cooldown {
			get { return coolDown; }
			set { coolDown = value; }
		}

        public bool IsInfestated{
            get { return Effects.ContainsKey("Infestation"); }
        }

		#endregion IElement Members

		#region IElement Methods

		/// <summary>
		/// Validates the movement of the unit
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dst"></param>
		/// <returns></returns>
		public bool ValidateMove( IBattleCoordinate src, IBattleCoordinate dst ) {
			return MoveChecker.ParsePosition(Unit.MovementType, src, dst, Position);
		}

		/// <summary>
		/// Creates a copy of this object by reference
		/// </summary>
		public IElement Clone() {
			Element e = new Element(Unit, Quantity, Coordinate, Owner);
			e.effects = Effects;
			e.CanBeMoved = CanBeMoved;
			e.CanUseSpecialAbilities = CanUseSpecialAbilities;
			e.Position = Position;
			e.RemainingDefense = RemainingDefense;
			e.Cooldown = Cooldown;
			return e;
		}

		/// <summary>
		/// Resolves the attack cycle of an element
		/// </summary>
		/// <param name="BattleInfo">Object that represents the battle</param>
		/// <param name="target">Unit that is being targeted</param>
		/// <param name="executeDefense">Executres the defense</param>
		public void ResolveAttackCycle( IBattleInfo BattleInfo, IElement target, bool executeDefense ) {
			ResolveAttack(BattleInfo, target);
			ResolvePosAttack(BattleInfo, target);	
			ResolveDefense(BattleInfo, target,executeDefense);
			ResolvePosDefense(BattleInfo, target);			
		}

		#endregion IElement Methods

		#region IElementAttack Members

		/// <summary>
		/// Resolves an element Attack
		/// </summary>
		/// <param name="battleInfo">Current battle Information</param>
		/// <param name="target">Element that represents the target</param>
		private void ResolveAttack( IBattleInfo battleInfo, IElement target ) {
			AttackUtils.ResolveAttack(battleInfo, this, target);
		}

		/// <summary>
		/// Resolves the events after the attack
		/// </summary>
		/// <param name="battleInfo">Current battle Information</param>
		/// <param name="target">Element that represents the target</param>
		private void ResolvePosAttack( IBattleInfo battleInfo, IElement target ) {
			if (CanUseSpecialAbilities) {
				ResolveSpecialMove(Unit.PosAttackMoves, battleInfo, this, target);
			}
		}

		/// <summary>
		/// Resolves teh defense of the target
		/// </summary>
		/// <param name="battleInfo">Current battle Information</param>
		/// <param name="target">Element that represents the target</param>
		/// <param name="executeDefense">Defense can be executed</param>
		private void ResolveDefense(IBattleInfo battleInfo, IElement target, bool executeDefense) {
			if (executeDefense && target.CanUseSpecialAbilities && target.CanBeMoved) {
				ResolveSpecialMove(target.Unit.DefenseMoves, battleInfo, target, this);
			}
		}

		/// <summary>
		/// Resolves the events after de defense of the target
		/// </summary>
		/// <param name="battleInfo">Current battle Information</param>
		/// <param name="target">Element that represents the target</param>
		private void ResolvePosDefense( IBattleInfo battleInfo, IElement target ) {
			if (CanUseSpecialAbilities) {
				ResolveSpecialMove(Unit.PosDefenseMoves, battleInfo, this, target);
			}
		}

		#endregion IElementAttack Members

		#region Object Override

		public override string ToString() {
			if( Quantity == 0 ) {
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("{0}-{1}-{2}-{3}", Unit.Code, Coordinate, Quantity, Position );

			if( RemainingDefense != Unit.Defense ) {
				builder.AppendFormat("-{0}", RemainingDefense);
			}

			if( Effects.Count > 0 ) {
				builder.Append("-");
				builder.Append(EffectsToString());
			}

			return builder.ToString();
		}

		/// <summary>
		/// Converts the element to Json
		/// </summary>
		/// <returns></returns>
		public string ToJson() {
			bool Paralysed = Effects.ContainsKey("Paralyze");
            bool infestation = IsInfestated;
			bool hasAbility = !Effects.ContainsKey("RemoveAbility");

			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("'{0}' : {{", Coordinate);
			builder.AppendFormat("'remainingDefense': {0}", RemainingDefense);
			builder.AppendFormat(",'coolDown': {0}", coolDown);
			builder.AppendFormat(",'hasAbility': {0}", hasAbility.ToString().ToLower());
			
			if( Paralysed ) {
				builder.AppendFormat(",'paralysed': {0}", Paralysed.ToString().ToLower());
			}
			if( infestation ) {
				builder.AppendFormat(",'infestated': {0}", infestation.ToString().ToLower());	
			}
			
			
			builder.Append("}");

			return builder.ToString();
		}

		#endregion Object Override

		#region Public

		/// <summary>
		/// Adds an new effect to this element
		/// </summary>
		/// <param name="effect">Effect to add</param>
		public void AddEffect(IEffect effect ) {
			if( Effects.ContainsKey(effect.Name) ) {
				RenewEffect(effect);
			}else {
				AddNewEffect(effect);
			}
		}

		/// <summary>
		/// Adds an effect 
		/// </summary>
		/// <param name="element">Element from where to obtain the effect</param>
		public void AddEffects( IElement element ) {
			foreach (KeyValuePair<string, List<IEffect>> pair in effects) {
                List<IEffect> e = new List<IEffect>(pair.Value);
				foreach (IEffect effect in e ) {
					AddEffect(effect);	
				}
			} 
		}

		/// <summary>
		/// Resolves all the effects
		/// </summary>
		public void ResolveEffects( IBattleInfo battleInfo ) {
			Dictionary<string, List<IEffect>> tempEffects = new Dictionary<string, List<IEffect>>(Effects);

			foreach (string effect in tempEffects.Keys) {
				List<IEffect> currEffects = new List<IEffect>(tempEffects[effect]);
				foreach (IEffect currEffect in currEffects) {
					if (!currEffect.Resolved) {
						if (currEffect.Resolve(battleInfo)) {
							Effects[effect].Remove(currEffect);
						}
					}
				}

			}
		}

		#endregion Public

		#region IUnitBonus Members

		/// <summary>
		/// Gets the attack with all the bonus
		/// </summary>
		public int GetAttack( Terrain terrain, IUnitInfo target ) {
			return Unit.GetAttack(terrain, target);
		}

		/// <summary>
		/// Gets the defense with all the bonus
		/// </summary>
		public int GetDefense( Terrain terrain, IUnitInfo target ) {
			return Unit.GetDefense(terrain, target);
		}

		/// <summary>
		/// Gets the range with all the bonus
		/// </summary>
		public int GetRange( Terrain terrain, IUnitInfo target ) {
			return Unit.GetRange(terrain, target);
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Builds a new element with the unit, it's quantity and it's posistion on the board
		/// </summary>
		public Element( IUnitInfo unit, int quantity, IBattleCoordinate coordinate, IBattlePlayer owner ) {
			Unit = unit;
			Quantity = quantity;
			OriginalQuantity = quantity;
			Coordinate = coordinate;
			Owner = owner;
			Position = PositionType.N;
			RemainingDefense = unit.Defense;
		}

		/// <summary>
		/// Builds a new element with the unit, it's quantity and it's posistion on the board
		/// </summary>
		public Element( IUnitInfo unit, int quantity, IBattleCoordinate coordinate ) {
			Unit = unit;
			Quantity = quantity;
			OriginalQuantity = quantity;
			Coordinate = coordinate;
			Owner = null;
			Position = PositionType.N;
			RemainingDefense = unit.Defense;
		}

		/// <summary>
		/// Builds a new element with the unit and quantity
		/// </summary>
		public Element( IUnitInfo unit, int quantity, IBattlePlayer owner ) {
			Unit = unit;
			Quantity = quantity;
			OriginalQuantity = quantity;
			Owner = owner;
			Coordinate = null;
			Position = PositionType.N;
			RemainingDefense = unit.Defense;
		}

		/// <summary>
		/// Builds a new element with the unit and quantity
		/// </summary>
		public Element( IUnitInfo unit, int quantity ) {
			Unit = unit;
			Quantity = quantity;
			OriginalQuantity = quantity;
			Owner = null;
			Coordinate = null;
			Position = PositionType.N;
			RemainingDefense = unit.Defense;
		}

		#endregion Constructor
	}
}
