using System;
using System.Collections.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a resource 
	/// </summary>
	public class ResourceQuantity : IResourceQuantity {

		#region Fields

        private static readonly List<IResourceInfo> resources = RulesUtils.GetIntrinsicNonConceptualResources();
		private readonly static Random random = new Random((int)DateTime.Now.Ticks);
		private readonly IResourceInfo resource;
		private readonly int quantity;

		#endregion Fields

		#region Properties

		public IResourceInfo Resource {
			get { return resource; }
		}

		public int Quantity {
			get { return quantity; }
		}

		#endregion Properties

		#region Private

		private static IResourceInfo ChooseRandomResource() {
			int idx = random.Next(0, resources.Count);
			return resources[idx];
		}

		private static IResourceInfo ChooseRandomResource(IPlayer player) {
			List<IResourceInfo> playerResources = RulesUtils.GetBasicResources(player);
			int idx = random.Next(0, playerResources.Count);
            return playerResources[idx];
		}

		private static int ChooseRandomQuantity(IResourceInfo resource) {
			if( resource.IsRare) {
				return random.Next(1, 11);
			}
			return random.Next(10, 51);
		}

		#endregion Private

		#region Public

		public override string ToString() {
			return string.Format("{0} {1}", Quantity, Resource.Name);
		}

		#endregion

		#region Constructor

		public ResourceQuantity() {
			resource = ChooseRandomResource();
			quantity = ChooseRandomQuantity(Resource);
		}

		public ResourceQuantity(IPlayer player) {
			resource = ChooseRandomResource(player);
			quantity = ChooseRandomQuantity(Resource);
		}

		public ResourceQuantity(int level) {
			resource = RulesUtils.GetRandomRareResource();
			quantity = random.Next(level*50, level*200);
		}

		public ResourceQuantity(IResourceInfo resource, int quantity) {
			this.resource = resource;
			this.quantity = quantity;
		}

		#endregion Constructor

	}
}
