using System;
using BotHandler;
using BotHandler.Engine;
using NUnit.Framework;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class AITest : BaseTests {

        //[Test]
        //public void AILoad() {
		//    Bot001Calculator m = new Bot001Calculator(Terrain.Space);

        //    SimpleElement[,] elements = new SimpleElement[8, 8];
        //    elements[0, 7] = new SimpleElement(1009, 10, 'N');
        //    elements[0, 6] = new SimpleElement(1014, 10, 'N');
        //    elements[0, 5] = new SimpleElement(1003, 10, 'N');
        //    elements[0, 4] = new SimpleElement(1024, 10, 'N');
        //    elements[0, 3] = new SimpleElement(1020, 10, 'N');
        //    elements[0, 2] = new SimpleElement(1026, 10, 'N');
        //    elements[0, 1] = new SimpleElement(1023, 10, 'N');
        //    elements[0, 0] = new SimpleElement(1029, 10, 'N');


        //    elements[7, 0] = new SimpleElement(9, 10, 'S');
        //    elements[7, 1] = new SimpleElement(14, 10, 'S');
        //    elements[7, 2] = new SimpleElement(3, 10, 'S');
        //    elements[7, 3] = new SimpleElement(24, 10, 'S');
        //    elements[7, 4] = new SimpleElement(20, 10, 'S');
        //    elements[7, 5] = new SimpleElement(23, 10, 'S');
        //    elements[7, 6] = new SimpleElement(29, 10, 'S');
        //    elements[7, 7] = new SimpleElement(26, 10, 'S');

        //    string s = m.Calculate(elements);
        //    Console.WriteLine("Node Count: {0}", Node.NodeCount);
        //}

        [Test]
        public void AILoad2() {
			Bot001Calculator m = new Bot001Calculator(Terrain.Space);

            SimpleElement[,] elements = new SimpleElement[8, 8];
            elements[0, 7] = new SimpleElement(1009, 10, 'N');
            elements[0, 6] = new SimpleElement(1014, 10, 'N');
            elements[0, 5] = new SimpleElement(1003, 10, 'N');
            elements[0, 4] = new SimpleElement(1024, 10, 'N');
            elements[0, 3] = new SimpleElement(1020, 10, 'N');
            elements[0, 2] = new SimpleElement(1026, 10, 'N');
            elements[0, 1] = new SimpleElement(1023, 10, 'N');
            elements[0, 0] = new SimpleElement(1029, 10, 'N');
            elements[1, 7] = new SimpleElement(1009, 10, 'N');
            elements[1, 6] = new SimpleElement(1014, 10, 'N');
            elements[1, 5] = new SimpleElement(1003, 10, 'N');
            elements[1, 4] = new SimpleElement(1024, 10, 'N');
            elements[1, 3] = new SimpleElement(1020, 10, 'N');
            elements[1, 2] = new SimpleElement(1026, 10, 'N');
            elements[1, 1] = new SimpleElement(1023, 10, 'N');
            elements[1, 0] = new SimpleElement(1029, 10, 'N');

            elements[7, 0] = new SimpleElement(9, 10, 'S');
            elements[7, 1] = new SimpleElement(14, 10, 'S');
            elements[7, 2] = new SimpleElement(3, 10, 'S');
            elements[7, 3] = new SimpleElement(24, 10, 'S');
            elements[7, 4] = new SimpleElement(20, 10, 'S');
            elements[7, 5] = new SimpleElement(23, 10, 'S');
            elements[7, 6] = new SimpleElement(29, 10, 'S');
            elements[7, 7] = new SimpleElement(26, 10, 'S');
            elements[6, 0] = new SimpleElement(9, 10, 'S');
            elements[6, 1] = new SimpleElement(14, 10, 'S');
            elements[6, 2] = new SimpleElement(3, 10, 'S');
            elements[6, 3] = new SimpleElement(24, 10, 'S');
            elements[6, 4] = new SimpleElement(20, 10, 'S');
            elements[6, 5] = new SimpleElement(23, 10, 'S');
            elements[6, 6] = new SimpleElement(29, 10, 'S');
            elements[6, 7] = new SimpleElement(26, 10, 'S');
            DateTime start = DateTime.Now;
            string s = m.Calculate(elements);
            Console.WriteLine("Time Spent: {0} sec", (DateTime.Now - start).TotalSeconds);
            Console.WriteLine("Node Count: {0}", Node.NodeCount);
        }

		[Test]
		public void AILoad3() {
			Bot001Calculator m = new Bot001Calculator(Terrain.Space);

			SimpleElement[,] elements = new SimpleElement[8, 8];
			elements[0, 7] = new SimpleElement(1038, 10, 'N');
			elements[7, 0] = new SimpleElement(38, 10, 'S');

			DateTime start = DateTime.Now;
			string s = m.Calculate(elements);
			Console.WriteLine("Time Spent: {0} sec", (DateTime.Now - start).TotalSeconds);
			Console.WriteLine("Node Count: {0}", Node.NodeCount);
		}
	}
}
