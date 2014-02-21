using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;

namespace OrionsBeltTests {
	public class BaseTests {
		static BaseTests() {
			IPersistanceProvider p = Persistance.Instance;
			Persistance.Instance = new MemoryProvider();
            Clock.Instance = new TickClock(150, 10);
			Server.IsInTests = true;
		}
	}
}
