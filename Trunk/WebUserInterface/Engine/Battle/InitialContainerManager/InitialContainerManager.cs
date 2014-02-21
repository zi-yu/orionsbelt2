using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public abstract class InitialContainerManager {

		#region Fields

		protected List<IBattlePlayer> players;

		#endregion Fields

		#region Properties

		public virtual bool LeftPositioned {
			get { throw new UIException("This property cannot be used"); }
		}

		public virtual bool RightPositioned {
			get { throw new UIException("This property cannot be used"); }
		}

		public virtual bool TopPositioned {
			get { throw new UIException("This property cannot be used"); }
		}

		public virtual bool BottomPositioned {
			get { throw new UIException("This property cannot be used"); }
		}

		#endregion Properties

		#region Virtual

		public virtual List<IElement> Left() {
			return null;
		}

		public virtual List<IElement> Right() {
			return null;
		}

		public virtual List<IElement> Top() {
			return null;
		}

		public virtual List<IElement> Bottom() {
			return null;
		}

		public virtual bool HasPositioned(int id) {
			throw new UIException("This method cannot be used");
		}

		public virtual List<IElement> GetPlayerElements(int id) {
			throw new UIException("This method cannot be used");
		}

		public virtual IBattlePlayer GetPlayer(int id) {
			throw new UIException("This method cannot be used");
		}

		public virtual int GetPlayerNumber(int id) {
			throw new UIException("This method cannot be used");
		}

		#endregion Virtual

		#region Constructor

		public InitialContainerManager( List<IBattlePlayer> players ) {
			this.players = players;
		}

		#endregion Constructor

	}
}
