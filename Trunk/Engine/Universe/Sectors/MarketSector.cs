using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe
{

    /// <summary>
    /// Represents a sector of empty space
    /// </summary>
    [FactoryKey("MarketSector")]
    public class MarketSector : Sector
    {

        #region Fields

        private static readonly string type = "MarketSector";
        private int marketId;

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
            get { return "m"; }
        }

        public int MarketId
        {
            get { return marketId; }
            set { Touch(); marketId = value; }
        }

        public Market Market{
            get { return Storage.Markets[0]; }
        }

        #endregion Properties

        #region Private

        protected override object CreateSector(SectorStorage sectorStorage)
        {
			return new MarketSector(sectorStorage);
        }

        #endregion Private

        #region Public

		public override bool IsDirty {
			get { return false; }
			set { }
		}

		#endregion Public

        #region Constructor

        public MarketSector() { }

        public MarketSector(Coordinate system, Coordinate sector, int level)
            : base(system, sector, level)
        {
        }

        public MarketSector(SectorStorage sectorStorage)
            : base(sectorStorage)
        {
			marketId = int.Parse(sectorStorage.AdditionalInformation);
        }

        public override void UpdateStorage()
        {
            base.UpdateStorage();
            storage.AdditionalInformation = marketId.ToString();
        }

        #endregion Constructor

    }
}
