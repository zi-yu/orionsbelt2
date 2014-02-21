using System.Xml.XPath;

namespace BotHandler.Engine {
	public class Player {

		#region Fields

		private int id;
		private string name;

		#endregion Fields

		#region Properties

		public int Id {
			get { return id; }
			set { id = value; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		#endregion Properties

		#region Constructor

		public Player(int id, string name) {
			Id = id;
			Name = name;
		}

		public Player(XPathNodeIterator iter) {
			Id = XPathUtils.GetAttributeInt(iter, "id");
			Name = iter.Current.Value;
		}

		#endregion Constructor

		
	}
}
