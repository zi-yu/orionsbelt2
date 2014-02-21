using System.Xml.XPath;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;

namespace BotHandler.Engine {
	public class Unit {
		
		#region Fields

		private int quantity;
		private readonly string name;
		private readonly string code;
        private readonly IUnitInfo info;

		#endregion Fields

		#region Properties

		public int Quantity {
			get { return quantity; }
            set { quantity = value;  }
		}

		public string Name {
			get { return name; }
		}

		public string Code {
			get { return code; }
		}

        public IUnitInfo Info {
            get { return info; }
        }

		#endregion Properties

		#region Constructor

		public Unit(XPathNodeIterator iter) {
			quantity = XPathUtils.GetAttributeInt(iter,"quantity");
			name = XPathUtils.GetAttribute(iter, "name");
			code = XPathUtils.GetAttribute(iter, "code");
            info = RulesUtils.GetUnit(name);
		}

        public Unit( Unit n, int quantity) {
            this.quantity = quantity;
            name = n.Name;
            code = n.Code;
            info = n.Info;
        }

		#endregion Constructor

	}
}
