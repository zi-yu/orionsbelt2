 using System.IO;
 using OrionsBelt.Engine.Universe;
 using OrionsBelt.RulesCore.Interfaces;
 using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class BugsWormHoleSectorInformation : SectorInformation{

		#region Fields

		private readonly int visibilityRange = 1;

		#endregion Fields

		#region Properties

		public override bool IsWormHole {
			get {return true;}
		}

		public override bool IsUltimate {
			get {return true;}
		}

		public override int HeightVisibility {
			get { return visibilityRange; }
		}

		public override int WidthVisibility {
			get { return visibilityRange; }
		}

		public override bool CanBeSeen {
			get { return !(Visibility is Discovered || Visibility is Undiscovered); }
		}

		public override UniverseVisibility VisibleToken {
			get { return FleetVisible.Instance; }
		}

		public override string HtmlAttributes {
			get { return string.Format(" isPrivate='true' "); }
		}

		#endregion Properties

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", LanguageManager.Instance.Get("WormHole"));
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);
                writer.Write(",t:'{0}'", ShortType);
                writer.Write(",ca:false,cm:true,ty:'w'");
                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());
                writer.Write(",a:'{0}'", GetAlliance(Owner));
                writer.Write(",s:'{0}'", GetState(Owner));
                writer.Write(",aid:{0}", GetAllianceId(Owner));
                writer.Write("}");
                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		public BugsWormHoleSectorInformation(ISector sector)
			: base(sector) {
			if( sector.Owner.UltimateWeaponLevel > 5 ) {
				visibilityRange = 2;
			}
		}

		#endregion Constructor

	}
}
