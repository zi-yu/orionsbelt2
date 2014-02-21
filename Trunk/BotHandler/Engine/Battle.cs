
using System;
using System.Collections.Generic;
using System.Xml.XPath;
using OrionsBelt.RulesCore.Enum;

namespace BotHandler.Engine {
	public class Battle {

		#region Fields

		private int id;
		private Terrain terrain;
        private int turn;
		private string state;
		private string responseUrl;
		private int currentPlayerOwnerId;
		private int currentPlayerOwnerBotId;
		private readonly List<Player> players = new List<Player>();
		private readonly List<Unit> units = new List<Unit>();
        private readonly Dictionary<Coordinate, Element> elements = new Dictionary<Coordinate, Element>();

		#endregion Fields

		#region Properties
        
		public int Id {
			get { return id; }
		}

        public int Turn {
            get { return turn;  }
        }

        public bool CanAttack {
            get { return Turn != 1; }
        }

		public string State {
			get { return state; }
		}

		public string ResponseUrl {
			get { return responseUrl; }
		}
		
		public int CurrentPlayerOwnerId {
			get { return currentPlayerOwnerId; }
		}
		
		public List<Unit> Units {
			get { return units; }
		}

		public List<Player> Players {
			get { return players; }
		}

        public Dictionary<Coordinate, Element> Elements {
            get { return elements; }
        }

		public Terrain Terrain {
			get { return terrain; }
		}

		public int CurrentPlayerOwnerBotId {
			get { return currentPlayerOwnerBotId; }
		}

		#endregion Properties

		#region Private

        private void LoadPlayers(XPathNodeIterator nav){
			XPathNodeIterator iter = nav.Current.Select("Players/Player");
			while (iter.MoveNext()) {
				Players.Add(new Player(iter));
			}
		}

        private void LoadUnits(XPathNodeIterator nav){
            XPathNodeIterator iter = nav.Current.Select("Units/Unit");
			while (iter.MoveNext()) {
				Units.Add(new Unit(iter));
			}
		}

        private void LoadElements(XPathNodeIterator nav){
            XPathNodeIterator iter = nav.Current.Select("Elements/Element");
			while (iter.MoveNext()) {
			    Element element = new Element(iter);
                elements.Add(element.Coordinate, element);
			}
		}

        private void Load(XPathNodeIterator nav){
            id = XPathUtils.GetAttributeInt(nav, "id");
			terrain = (Terrain)Enum.Parse(typeof(Terrain), XPathUtils.GetAttribute(nav, "terrain"));
            
            state = XPathUtils.GetAttribute(nav, "state"); ;
            responseUrl = XPathUtils.Get(nav, "ResponseUrl");
            currentPlayerOwnerId = XPathUtils.GetInt(nav, "CurrentPlayer/@ownerId");
			currentPlayerOwnerBotId = XPathUtils.GetInt(nav, "CurrentPlayer/@botId");
            LoadPlayers(nav);
            if (State.Equals("deploy")){
                LoadUnits(nav);
            }
            if (State.Equals("battle")){
                turn = XPathUtils.GetAttributeInt(nav, "turn");
                LoadElements(nav);
            }
        }

		#endregion Private

        #region Public

        public SimpleElement[,] GetSimpleRepresentation(){
            SimpleElement[,] board = new SimpleElement[8, 8];
            foreach (Element element in elements.Values){
				short id = UnitMappings.GetUnitId(element);
				if( element.CanbeMoved ) {
					if( element.OwnerId != CurrentPlayerOwnerId) {
						id += 1000;
					}
					board[element.Coordinate.X - 1, element.Coordinate.Y - 1] = new SimpleElement(id, (short)element.Quantity,element.Direction[0]);
				}else {
					id += 10000;
                    board[element.Coordinate.X - 1, element.Coordinate.Y - 1] = new SimpleElement(id, 0, element.Direction[0]);
				}
            }
            return board;
        }

		public bool SectorHasElement(int x, int y) {
			Coordinate c = new Coordinate((short)x, (short)y);
			return elements.ContainsKey(c);
		}

		public bool SectorHasElement(short x, short y) {
            Coordinate c = new Coordinate(x, y);
            return elements.ContainsKey(c);
        }

        public IEnumerable<Element> GetCurrentPlayerElements()
        {
            foreach (Element elem in Elements.Values) {
                if (elem.OwnerId == CurrentPlayerOwnerId) {
                    yield return elem;
                }
            }   
        }

        public IEnumerable<Element> GetElementsThatMayBeAttackedBy(Element element)
        {
            foreach (Element target in Elements.Values) {
                if (AttackChecker.CanAttack(this, element, target)) {
                    yield return target;
                }
            }
            
        }

        #endregion Public

		#region Constructor
		public Battle() {
			
		}
		
		public Battle(XPathNavigator nav) {
            XPathNodeIterator n = nav.Select("Battle");
		    n.MoveNext();
            Load(n);
		}

        public Battle(XPathNodeIterator nav) {
			Load(nav);
		}

		#endregion Constructor

    }
}
