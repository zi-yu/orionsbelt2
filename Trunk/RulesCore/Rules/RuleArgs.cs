using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Rules {

    /// <summary>
    ///  Arguments for a rule
    /// </summary>
    public class RuleArgs {

        #region Properties

        private int quantity;

        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }

        private IResourceOwner owner;

        public IResourceOwner ResourceOwner {
            get { return owner; }
            set { owner = value; }
        }

        public IPlanet Planet {
            get {
                IPlanet planet = ResourceOwner as IPlanet;
                if (planet == null) {
                    throw new RulesException("Can't Resolve Planet");
                }
                return planet;
            }
        }

        public IPlayer Player {
            get {
                IPlayer player = ResourceOwner as IPlayer;
                if (player != null) {
                    return player;
                }
                return Planet.Owner;
            }
        }

        private IPlanetResource planetResource;

	    public IPlanetResource PlanetResource {
		    get { return planetResource;}
		    set { planetResource = value;}
	    }
	
        private ResourceState nextState = ResourceState.UnAvailable;

	    public ResourceState NextState {
		    get { return nextState;}
		    set { nextState = value;}
	    }

        private int nextLevel = 0;

        public int TargetLevel{
            get { return nextLevel; }
            set { nextLevel = value; }
        }

        #endregion Properties

        #region Static Utils

        public static RuleArgs Create(IPlanetResource resource, ResourceState nextState, int nextLevel)
        {
            return Create(resource.Owner, resource, nextState, nextLevel, 1);
        }

        internal static RuleArgs Create(IPlanet planet, ResourceState nextState)
        {
            RuleArgs args = new RuleArgs();

            args.NextState = nextState;
            args.TargetLevel = 1;
            args.ResourceOwner = planet;
            args.Quantity = 1;

            return args;
        }

        public static RuleArgs Create(IResourceOwner owner, IPlanetResource resource, ResourceState nextState, int nextLevel, int quantity)
        {
            RuleArgs args = new RuleArgs();

            args.PlanetResource = resource;
            args.NextState = nextState;
            args.TargetLevel = nextLevel;
            args.ResourceOwner = owner;
            args.Quantity = quantity;

            return args;
        }

        #endregion Static Utils

    };
}
