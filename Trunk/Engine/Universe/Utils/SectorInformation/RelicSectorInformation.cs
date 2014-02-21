using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class RelicSectorInformation : SectorInformation{

		#region Fields

		private readonly RelicSector relic;

		#endregion Fields

		#region Properties

		protected string CanConquer() {
			if (sector.Owner != null) {
				return falseString;
			}
			return trueString;
		}

        public override bool IsRelic{
            get{return true;}
        }

        public override bool CanBeSeen {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); ; }
		}

        public override UniverseVisibility VisibleToken{
            get { return FleetVisible.Instance; }
        }

		#endregion Properties

		#region Protected

		#endregion Protected

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", LanguageManager.Localize("Relic"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());
                writer.Write(",b:{0}", ConvertToString(relic.IsInBattle));
                writer.Write(",id:{0}", relic.Storage.Id);
                writer.Write(",ty:'r'");
                writer.Write(",uty:'r'");
                writer.Write(",ca:{0}", CanAttack());
                writer.Write(",cc:{0}", CanConquer());
                writer.Write(",a:'{0}'", GetAlliance());
                writer.Write(",s:'{0}'", GetState());
                writer.Write(",aid:{0}", GetAllianceId());
                writer.Write("}");
                return writer.ToString();
            }
		}


		#endregion Public

		#region Constructor

		public RelicSectorInformation(ISector sector)
			: base(sector) {
			relic = (RelicSector)sector;
		}

		#endregion Constructor

	}
}
