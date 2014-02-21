using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Rules {

    public class Cost : IRule  {

        #region Properties

        private int levelAttenuation;

        public int LevelAttenuation
        {
            get { return levelAttenuation; }
            set { levelAttenuation = value; }
        }

        private int pow;

        public int Pow
        {
            get { return pow; }
            set { pow = value; }
        }

        private int fixedPrice = -1;

        public int FixedPrice
        {
            get { return fixedPrice; }
            set { fixedPrice = value; }
        }

        private RuleArgs currentArgs;

        public RuleArgs CurrentArgs
        {
            get { return currentArgs; }
            set { currentArgs = value; }
        }
	

        private int subtract;

        public int Subtract
        {
            get { return subtract; }
            set { subtract = value; }
        }

        private int mulFactor;

        public int MulFactor
        {
            get { return mulFactor; }
            set { mulFactor = value; }
        }

        private int mulAttenuation;

        public int MulAttenuation
        {
            get { return mulAttenuation; }
            set { mulAttenuation = value; }
        }
	

        private IIntrinsicInfo costResource;

        public IIntrinsicInfo CostResource
        {
            get { return costResource; }
            set { costResource = value; }
        }

        private IResourceWithRulesInfo resource;

        public IResourceWithRulesInfo Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        private bool ignoreLevelInPow = false;

        public bool IgnoreLevelInPow
        {
            get { return ignoreLevelInPow; }
            set { ignoreLevelInPow = value; }
        }

        #endregion Properties

        #region IRule Members

        public ResourceState TargetState {
            get { return ResourceState.Running; }
        }

        public bool IsGlobal {
            get { return false; }
        }

        public ResourceState NextState {
            get { return ResourceState.InQueue; }
        }

        public Result CanProcess(RuleArgs args)
        {
            CurrentArgs = args;
            int cost = GetCost(args) * args.Quantity;

            if (cost == 0) {
                return Result.Ignore;
            }

            bool available = args.ResourceOwner.IsResourceAvailable(CostResource, cost);
            CostResult costResult = new CostResult(CostResource, cost, available);
                
            return Result.Create(costResult);
        }

        public bool AppliesToArgs(RuleArgs args)
        {
            return args.NextState == NextState;
        }

        public bool UndoAppliesToArgs(RuleArgs args)
        {
            return args.PlanetResource.State == ResourceState.Deleted || args.PlanetResource.State == ResourceState.Running;
        }

        public bool IsForLevel(int level)
        {
            if (FixedPrice > 0) {
                return true;
            }
            if (level == 1 && Resource.InitialState == ResourceState.Running) {
                return false;
            }
            return true;
        }

        public void Process(RuleArgs args)
        {
            ProcessCost(args, 1);
        }

        private void ProcessCost(RuleArgs args, int factor)
        {
            CurrentArgs = args;
            int cost = GetCost(args) * args.Quantity * factor;
            args.ResourceOwner.RemoveQuantity(CostResource, cost);
        }

        public int GetCost(int level)
        {
            return GetCost(level, 1);
        }

        public int GetCost(int level, double deduction)
        { 
            double attenuation = 1;
            if (this.Resource != null) {
                attenuation = this.Resource.GetBaseCostAttenuation(CurrentArgs, CostResource);
            }
            if (FixedPrice > 0) {
                double basePrice = FixedPrice;
                return (int)Math.Ceiling(basePrice * attenuation * deduction);
            }
            return Convert.ToInt32(Calculate( LevelAttenuation, MulAttenuation, MulFactor, Pow, Subtract, level, ignoreLevelInPow) * attenuation * deduction);
        }

        public int GetCost(RuleArgs args)
        {
            if (!CostResource.IsRare && args.Player.HasService(ServiceType.BuyIntrinsicDeduction)
                ||
                CostResource.IsRare && args.Player.HasService(ServiceType.BuyRareDeduction))
            {
                return GetCost(args.TargetLevel, 0.70);
            }
            return GetCost(args.TargetLevel, 1);
        }

        public void Undo(RuleArgs args)
        {
            ProcessCost(args, -1);
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return string.Format("Cost: {0}", CostResource.Name);
        }

        public string ToString(IMessageParameterTranslator translator, IResourceWithRulesInfo info, int targetLevel)
        {
            int cost = GetCost(targetLevel);
            if (cost == 0) {
                return string.Empty;
            }
            return string.Format("{0} <a href='{1}'>{2}</a>",
                    cost,
                    ManualUtils.GetUrlOnResourcePage(CostResource),
                    translator.Translate(CostResource.Name)
                );
        }

        #endregion ToString

        #region Static Utils

        internal static void Add(IResourceWithRulesInfo info, Type costResource, int fixedCost)
        {
            Cost cost = new Cost();

            cost.CostResource = RulesUtils.GetIntrinsic(costResource.Name);
            cost.Resource = info;
            cost.FixedPrice = fixedCost;

            info.Rules.Register(cost);
        }

        internal static void Add(IResourceWithRulesInfo info, Type costResource, int start, int attenuation, int exponentialBase)
        {
            info.Rules.Register( Get(info, costResource, start, attenuation, exponentialBase) );
        }

        public static Cost Get(IResourceWithRulesInfo info, Type costResource, int start, int attenuation, int exponentialBase)
        {
            Cost cost = new Cost();

            cost.Resource = info;
            cost.CostResource = RulesUtils.GetIntrinsic(costResource.Name);

            cost.LevelAttenuation = attenuation;
            cost.Pow = exponentialBase;
            cost.MulFactor = 1;
            cost.subtract = -start;

            return cost;
        }

        internal static void Add(IResourceWithRulesInfo owner, Type type, int levelAttenuation, int mulAttenuation, int mulFactor, int pow, int subtract, bool ignoreLevelPow)
        {
            Cost cost = new Cost();

            cost.Resource = owner;
            cost.CostResource = RulesUtils.GetIntrinsic(type.Name);
            cost.LevelAttenuation = levelAttenuation;
            cost.Pow = pow;
            cost.mulAttenuation = mulAttenuation;
            cost.MulFactor = mulFactor;
            cost.subtract = subtract;
            cost.IgnoreLevelInPow = ignoreLevelPow;

            owner.Rules.Register(cost);
        }

        internal static void Add(IResourceWithRulesInfo owner, Type type, int levelAttenuation, int mulAttenuation, int mulFactor, int pow, int subtract)
        {
            Add(owner, type, levelAttenuation, mulAttenuation, mulFactor, pow, subtract, false);
        }

        public static Cost Get(Type costResource, int start, int attenuation, int exponentialBase)
        {
            return Get(costResource, start, attenuation, exponentialBase, false);
        }

        public static Cost Get(Type costResource, int start, int attenuation, int exponentialBase, bool ignoreLevelPow)
        {
            Cost cost = new Cost();

            cost.CostResource = RulesUtils.GetIntrinsic(costResource.Name);

            cost.LevelAttenuation = attenuation;
            cost.Pow = exponentialBase;
            cost.MulFactor = 1;
            cost.subtract = -start;
            cost.IgnoreLevelInPow = ignoreLevelPow;

            return cost;
        }

        public static int Calculate(double levelAttenuation, double mulAttenuation, double mulFactor, int pow, double subtract, int level)
        {
            return Calculate(levelAttenuation, mulAttenuation, mulFactor, pow, subtract, level, false);
        }

        public static int Calculate(double levelAttenuation, double mulAttenuation, double mulFactor, int pow, double subtract, int level, bool ignoreLevelInPow)
        {
            //=(Level/levelAttenuation)*mulFactor*POWER(Level;pow)-(mulFactor/mulAttenuation)-subtract

            double firstFactor = 1;
            double secondFactor = 0;

            if (levelAttenuation != 0) {
                firstFactor = level / levelAttenuation;
            }

            if (mulAttenuation != 0) {
                secondFactor = mulFactor / mulAttenuation;
            }

            int val;
            if (!ignoreLevelInPow)
            {
                val = (int) Math.Ceiling(firstFactor*mulFactor*Math.Pow(level, pow) - secondFactor - subtract);
            }else
            {
                val = (int)Math.Ceiling(firstFactor * mulFactor * Math.Pow(1, pow) - secondFactor - subtract);
            }
            if (val < 0) {
                return 0;
            }

            return val;
        }

        public static int CalculateDuration(double levelAttenuation, double mulAttenuation, double mulFactor, int pow, double subtract, int level)
        {
            return CalculateDuration(levelAttenuation, mulAttenuation, mulFactor, pow, subtract, level, false);
        }
                

        public static int CalculateDuration(double levelAttenuation, double mulAttenuation, double mulFactor, int pow, double subtract, int level, bool ignoreLevelInPow)
        {
            //=(Level/levelAttenuation)*mulFactor*POWER(Level;pow)-(mulFactor/mulAttenuation)-subtract

            double firstFactor = 1;
            double secondFactor = 0;

            if (levelAttenuation != 0)
            {
                firstFactor = level / levelAttenuation;
            }

            if (mulAttenuation != 0)
            {
                secondFactor = mulFactor / mulAttenuation;
            }

            int val;
            if (!ignoreLevelInPow)
            {
                val = (int)Math.Ceiling(6*(firstFactor * mulFactor * Math.Pow(level, pow) - secondFactor - subtract));
            }
            else
            {
                val = (int)Math.Ceiling(6*(firstFactor * mulFactor * Math.Pow(1, pow) - secondFactor - subtract));
            }
            if (val < 0)
            {
                return 0;
            }

            return val;
        }

        #endregion Static Utils

    };
}
