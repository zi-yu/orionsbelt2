using System;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Results;

namespace OrionsBelt.WebUserInterface.Engine {
	public class FleetChangesInterpreter {

		#region Fields

		private static readonly char[] changesSeparator = new char[]{ ';'};
		private static readonly char[] separator = new char[] { '-' };
		private delegate void Change(IFleetInfo srcFleet, IFleetInfo dstFleet, Result result, string element, int quantity);

		#endregion Fields

		#region Private

		private static IFleetInfo GetGleet(int srcId) {
			return PlayerUtils.Current.AllFleets.Find(delegate(IFleetInfo fleet) { return fleet.Id == srcId; });
		}

		private static Result GenericChange(Change change, string changes, bool isInPlanet) {
			Result result = new Result();
			string[] splittedChanges = changes.Split(changesSeparator, StringSplitOptions.RemoveEmptyEntries);
			foreach (string s in splittedChanges) {
				string[] changeOpt = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				GenericChangeFleet(change, changeOpt, result, isInPlanet);
			}
			foreach (IFleetInfo fleet in PlayerUtils.Current.AllFleets) {
				GameEngine.Persist(fleet);
			}
			return result;
		}

		private static void GenericChangeFleet(Change change, string[] changes, Result result, bool isInPlanet) {
			int srcId = int.Parse(changes[0]);
			int dstId = int.Parse(changes[1]);
			string element = changes[2];
			int quantity = int.Parse(changes[3]);

			IFleetInfo srcFleet = GetGleet(srcId);
			IFleetInfo dstFleet = GetGleet(dstId);

			if (srcFleet != null && dstFleet != null && !srcFleet.IsMoving && !dstFleet.IsMoving) {
				if( !isInPlanet ){
					List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(dstFleet.Location, 2);
					if( !coordinates.Contains(srcFleet.Location) ) {
						result.AddFailed(new FleetNotAround(srcFleet, dstFleet));
						return;
					}
				}

				change(srcFleet, dstFleet, result, element, quantity);
				return;
			}
		}

		private static void ChangeUnitsFromFleet(IFleetInfo srcFleet, IFleetInfo dstFleet, Result result, string unitName, int quantity) {
			if (!srcFleet.HasEnoughUnits(unitName, quantity)) {
				result.AddFailed(new NotEnoughUnits(srcFleet, unitName, quantity));
				return;
			}

			dstFleet.Add(unitName, quantity);
			srcFleet.Remove(unitName, quantity);
			result.AddPassed(new UnitsTransferedSuccessfully(srcFleet, dstFleet, unitName, quantity));
		}

		private static void ChangeResourceFromFleet(IFleetInfo srcFleet, IFleetInfo dstFleet, Result result, string resourceName, int quantity) {
			IResourceInfo resource = RulesUtils.GetResource(resourceName);

			int quant = srcFleet.GetCargoQuantity(resource);

			if (quant == 0 || quant < quantity) {
				result.AddFailed(new NotEnoughUnits(srcFleet, resourceName, quantity));
				return;
			}

			dstFleet.AddCargo(resource, quantity);
			srcFleet.UpdateCargo(resource, quant - quantity);
			result.AddPassed(new UnitsTransferedSuccessfully(srcFleet, dstFleet, resourceName, quantity));
		}

		#endregion Private

		#region Public

		public static Result Interpretate(string changes,bool isInPlanet) {
			return GenericChange(ChangeUnitsFromFleet, changes, isInPlanet);
		}

		public static Result InterpretateCargo(string cargoChanges, bool isInPlanet) {
			return GenericChange(ChangeResourceFromFleet, cargoChanges, isInPlanet);
		}

		#endregion Public
	}
}
