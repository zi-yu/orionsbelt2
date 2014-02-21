using System.Xml.XPath;
using OrionsBelt.RulesCore.Interfaces;

namespace BotHandler.Engine{
    
    public class Element{
        #region Fields

        private int id;
        private int ownerid;
        private int quantity;
        private int remainingDefense;
        private bool canbeMoved;
        private bool canUseSpecialHabilities;
        private bool isInfestated;
        private string direction;
        private string name;
        private string code;
        private IUnitInfo unit;
        private static readonly char[] separator = new char[]{'_'};
        private Coordinate coordinate;
        private string identifier;

        #endregion Fields

        #region Properties

        public int Id{
            get { return id; }
            set { id = value; }
        }

        public string Identifier {
            get { return identifier; }
        }

        public int OwnerId{
            get { return ownerid; }
            set { ownerid = value; }
        }

        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }

        public int RemainingDefense {
            get { return remainingDefense; }
            set { remainingDefense = value; }
        }

        public bool CanbeMoved {
            get { return canbeMoved; }
            set { canbeMoved = value; }
        }

        public bool CanUseSpecialHabilities {
            get { return canUseSpecialHabilities; }
            set { canUseSpecialHabilities = value; }
        }

        public bool IsInfestated {
            get { return isInfestated; }
            set { isInfestated = value; }
        }

        public string Direction {
            get { return direction; }
            set { direction = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Code {
            get { return code; }
            set { code = value; }
        }

        public IUnitInfo Unit {
            get { return unit; }
            set { unit = value; }
        }

        public Coordinate Coordinate {
            get{ return coordinate; }
            set { coordinate = value; }
        }

        #endregion Properties

        #region Private

        private void ParseCoordinate(string coord){
            string[] splitted = coord.Split(separator);
			short x = short.Parse(splitted[0]);
			short y = short.Parse(splitted[1]);
            coordinate = new Coordinate(x,y);
        }

        #endregion Private

        #region Public

        #endregion Public
        
        #region Constructor

		public Element() {}

    	public Element(XPathNodeIterator iter){
            Id = XPathUtils.GetAttributeInt(iter, "id");
            OwnerId = XPathUtils.GetAttributeInt(iter, "ownerId");
            Quantity = XPathUtils.GetAttributeInt(iter, "quantity");
            RemainingDefense = XPathUtils.GetAttributeInt(iter, "remainingDefense");
            CanbeMoved = XPathUtils.GetAttributeBool(iter, "canBeMoved");
            CanUseSpecialHabilities = XPathUtils.GetAttributeBool(iter, "canUseSpecialHabilities");
            Direction = XPathUtils.GetAttribute(iter, "direction");
            Name = XPathUtils.GetAttribute(iter, "name");
            Code = XPathUtils.GetAttribute(iter, "code");
            IsInfestated = XPathUtils.GetAttributeBool(iter, "isInfestated");
            string coord = XPathUtils.GetAttribute(iter, "coordinate");
            ParseCoordinate(coord);
            Unit = OrionsBelt.BattleCore.Unit.Create(Code);
            identifier = string.Format("{0}|{1}|{2}", Name, Coordinate, Quantity);
        }

        public Element(Element source)
        {
            Id = source.id;
            OwnerId = source.OwnerId;
            Quantity = source.Quantity;
            RemainingDefense = source.RemainingDefense;
            CanbeMoved = source.canbeMoved;
            CanUseSpecialHabilities = source.CanUseSpecialHabilities;
            Direction = source.Direction;
            Name = source.name;
            Code = source.Code;
            isInfestated = source.isInfestated;
            unit = source.unit;
            coordinate = source.coordinate;
            identifier = source.identifier;
        }

        #endregion Constructor

        #region Overriden

        public override string ToString()
        {
            return string.Format("{0}|{1}: {2} : {3} | {4}", Name, Code, Coordinate, Quantity, Direction);
        }

        #endregion Overriden
        
    }
}
