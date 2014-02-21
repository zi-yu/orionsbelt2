using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe
{

    /// <summary>
    /// Represents a sector of empty space
    /// </summary>
    [FactoryKey("PirateBaySector")]
    public class PirateBaySector : Sector
    {

        #region Fields

        private static readonly string type = "PirateBaySector";

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
            get { return "pb"; }
        }

        #endregion Properties

        #region Private

        protected override object CreateSector(SectorStorage sectorStorage)
        {
			return new PirateBaySector(sectorStorage);
        }

        #endregion Private

        #region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion Public

        #region Constructor

        public PirateBaySector() { }

        public PirateBaySector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
		}

        public PirateBaySector(SectorStorage sectorStorage)
            : base(sectorStorage)
        {

        }


        #endregion Constructor

    }
}
