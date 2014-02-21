using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe
{

    /// <summary>
    /// Represents a sector of empty space
    /// </summary>
    [FactoryKey("AcademySector")]
    public class AcademySector : Sector
    {

        #region Fields

        private static readonly string type = "AcademySector";

        #endregion Fields

        #region Properties

        public override string Type
        {
            get { return type; }
        }

        public override IPlayer Owner
        {
            get { return null; }
            set { }
        }

        public override bool IsStatic
        {
            get { return true; }
            set { }
        }

        public override bool IsConstructing
        {
            get { return false; }
            set { }
        }

        public override string DisplayTypeShort
        {
            get { return "c"; }
        }

        #endregion Properties

        #region Private

        protected override object CreateSector(SectorStorage sectorStorage)
        {
			return new AcademySector(sectorStorage);
        }

        #endregion Private

        #region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion Public

        #region Constructor

        public AcademySector() { }

        public AcademySector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
		}

        public AcademySector(SectorStorage sectorStorage)
            : base(sectorStorage)
        {

        }


        #endregion Constructor

    }
}
