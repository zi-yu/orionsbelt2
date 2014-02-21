using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class ArenaSectorInformation : SectorInformation{

		#region Fields

		private readonly ArenaSector arena;

		#endregion Fields

		#region Properties

		public override bool IsArena {
			get { return true; }
		}

		#endregion Properties

		#region Protected

		#endregion Protected

		#region Public

		public override string ToJson() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("'{0}_{1}':{{", Coordinate.System, Coordinate.Sector);
                writer.Write("n:'{0}'", arena.Arena.Name);
                writer.Write(",c:'{0}'", sector.Coordinate);
                writer.Write(",v:'{0}'", visibility);

                writer.Write(",o:'{0}'", GetOwnerName());
                writer.Write(",on:'{0}'", GetOwnerSimpleName());

                writer.Write(",b:{0}", ConvertToString(arena.Arena.IsInBattle > 0));
                writer.Write(",id:{0}", arena.Arena.Id);
                writer.Write(",ty:'a'");
                writer.Write(",uty:'a'");
                writer.Write("}");

                return writer.ToString();
            }
		}


		#endregion Public

		#region Constructor

		public ArenaSectorInformation(ISector sector)
			: base(sector) {
			arena = (ArenaSector)sector;
		}

		#endregion Constructor

	}
}
