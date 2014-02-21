using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;
using System;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// This class represents a unit
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseUnit : BaseResourceWithRules, IUnitInfo, IComparer<IUnitInfo> {

		#region Fields

    	protected List<ISpecialMove> posAttack = new List<ISpecialMove>();
		protected List<ISpecialMove> defense = new List<ISpecialMove>();
		protected List<ISpecialMove> posDefense = new List<ISpecialMove>();
		protected Dictionary<string, IBonus> bonus = new Dictionary<string, IBonus>();
		
		#endregion Fields

		#region BaseResource Implementation

		public override ResourceType Type {
            get { return ResourceType.Unit;  }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool CanAcumulate {
            get { return true; }
        }

        public override int MaxLevel {
            get { return 1;  }
        }

        public override bool IsBuildable {
            get { return UnitCategory != UnitCategory.Special; }
        }

        public override bool CanUnloadFromFleet {
            get { return true; }
        }

        #endregion BaseResource Implementation

        #region BaseResource Methods

        public override int GetFixedBuildDuration(int level, int quantity)
        {
            return BuildDuration * quantity;
        }

        public override double GetBaseCostAttenuation(RuleArgs args, IIntrinsicInfo resource)
        {
            return 0.25;
        }

        protected override void BuildOnCompleteRules()
        {
            base.BuildOnCompleteRules();
            UpdateFleetAfterConstruction.Add(this);
        }

        #endregion BaseResource Methods

        #region IUnitInfo Members

        public abstract int Attack { get;}

        public abstract int Defense{ get;}

		public abstract int Range { get; }

        public abstract string Code { get;}

		public abstract int UnitValue { get;}

		public abstract UnitType UnitType { get;}

		public abstract UnitCategory UnitCategory { get;}

		public abstract UnitDisplacement UnitDisplacement { get;}

		public abstract MovementType MovementType { get; }

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Ship;
            }
        }

        public virtual int MovementCost {
            get { return 1; }
        }

		public virtual int AttackCost {
            get { return 1; }
        }

        public bool IsBuilding  {
            get { return false; }
        }

		public virtual bool IsUltimate {
			get { return false; }
		}

		/// <summary>
		/// if this unit will be save in the database at the end of the battle
		/// </summary>
		public virtual bool CanBeSaved {
			get { return true; }
		}

		/// <summary>
		/// The value of the unit in battle with the bonus
		/// </summary>
		public virtual int GetFinalUnitValue( IBattlePlayer owner, IBattleStatistics statistics ) {
			return UnitValue;
		}

        public virtual int BuildDuration {
            get {
                double value = UnitValue;
                return Convert.ToInt32(Math.Ceiling( value / 10 ));
            }
        }

		/// <summary>
		/// The unit cooldown
		/// </summary>
		public virtual int CoolDown {
			get { return 0; }
		}

		/// <summary>
		/// If the unit is allowed to attack
		/// </summary>
		public virtual bool CanAttack{
			get { return true; }
		}

		public virtual bool IsShowable {
    		get{ return true;}
    	}

        #endregion

		#region IAttack Members

    	/// <summary>
    	/// Indicates if the unit has catapult
    	/// </summary>
    	public virtual bool Catapult {
    		get{ return false;}
    	}

		/// <summary>
		/// Special moves made in the Pos Attack Event
		/// </summary>
		public List<ISpecialMove> PosAttackMoves {
			get { return posAttack; }
		}

		/// <summary>
		/// Special moves made in the Defense Event
		/// </summary>
		public List<ISpecialMove> DefenseMoves {
			get { return defense; }
		}

		/// <summary>
		/// Special moves made in the Pos Defense Event
		/// </summary>
		public List<ISpecialMove> PosDefenseMoves {
			get { return posDefense; }
		}

		#endregion

		#region IUnitBonus Members

    	/// <summary>
    	/// Container with all the bonus
    	/// </summary>
    	public Dictionary<string, IBonus> Bonus {
			get { return bonus; }
    	}

    	/// <summary>
		/// Gets the attack with all the bonus
		/// </summary>
		public int GetAttack( Terrain terrain, IUnitInfo target ) {
			return Attack + BonusUtils.GetAttack(terrain, this, target ) ;
		}

		/// <summary>
		/// Gets the defense with all the bonus
		/// </summary>
		public int GetDefense( Terrain terrain, IUnitInfo target ) {
			return Defense + BonusUtils.GetDefense(terrain, this, target);
		}

		/// <summary>
		/// Gets the range with all the bonus
		/// </summary>
		public int GetRange( Terrain terrain, IUnitInfo target ) {
			return Range + BonusUtils.GetRange(terrain, this, target);
		}

		#endregion IUnitBonus Members

		#region Object Members

		public override bool Equals( object obj ) {
			IUnitInfo unitInfo = obj as IUnitInfo;
			if( null != unitInfo ) {
				return Name.Equals(unitInfo.Name);
			}
			return false;
		}

		public override int GetHashCode() {
			return Name.GetHashCode();
		}

		#endregion Object Members

		#region IComparer<IUnitInfo> Members

		public int Compare( IUnitInfo x, IUnitInfo y ) {
			return x.Name.CompareTo(y.Name);
		}

		#endregion
	};

}
