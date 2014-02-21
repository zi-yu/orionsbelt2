using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.BattleCore.Exceptions {

	public abstract class BattleException: OrionsBeltException {

		public BattleException()
			: base() { }

		public BattleException( string reason ) 
			: base(reason){}

	}

}
