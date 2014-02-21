using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using System.Threading;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ClockTests: BaseTests {

        #region TickClock

        [Test]
        public void TestIncrement()
        {
            TickClock clock = new TickClock(1, 10);

            clock.Advance();

            Assert.AreEqual(2, clock.Tick);
        }

        [Test]
        public void TestInterTickTime_SameTick()
        {
            TickClock clock = new TickClock(1, 1000);

            TimeSpan t1 = clock.GetTimeLeft(2);

            Thread.Sleep(100);

            TimeSpan t2 = clock.GetTimeLeft(2);

            Assert.Less(t2.TotalMilliseconds, t1.TotalMilliseconds);
        }

        [Test]
        public void TestInterTickTime_MultipleTicks()
        {
            TickClock clock = new TickClock(1, 1000);

            TimeSpan t1 = clock.GetTimeLeft(4);

            Thread.Sleep(100);

            TimeSpan t2 = clock.GetTimeLeft(4);

            Assert.Less(t2.TotalMilliseconds, t1.TotalMilliseconds);
            Assert.Greater(t2.TotalMilliseconds, clock.MillisPerTick * 2);
        }

        [Test]
        public void TestInterTickTime_ElapsedTime()
        {
            TickClock clock = new TickClock(1, 50);
            clock.Start();
            Thread.Sleep(50);
            Thread.Sleep(150);
            Assert.GreaterOrEqual(clock.Tick, 1);
        }

        #endregion TickClock

        #region Convertion

        [Test]
        public void ConvertToTicks_Test_10min_Tick()
        {
            int start = 1;
            int millisPerTick = 600000;
            int days = 1;
            CheckTickConversion(start, millisPerTick, days, 144);
            
        }

        [Test]
        public void ConvertToTicks_Test_2min_Tick()
        {
            int millisPerTick = 180000;
            int days = 1;
            int ticks = 480;
            CheckTickConversion(1, millisPerTick, days, ticks);
        }

        private static void CheckTickConversion(int start, int millisPerTick, int days, int ticks)
        {
            TickClock clock = new TickClock(start, millisPerTick);

            Assert.AreEqual(ticks, clock.ConvertToTicks(TimeSpan.FromDays(days)));
        }

        #endregion Convertion

        #region Time To Tick

        [Test]
        public void TimetoTick_1Sec()
        {
            TickClock clock = new TickClock(1, 60000);
            int millis =  clock.MillisToTick;
            
            Assert.Greater(millis, 55000);
            Assert.Less(millis, 65000);
        }

        [Test]
        public void TimetoTick_1Sec_With_Sleep()
        {
            TickClock clock = new TickClock(1, 60000);
            Thread.Sleep(1000);
            int millis = clock.MillisToTick;
            Assert.Greater(millis, 55000);
            Assert.Less(millis, 60000);
        }

        #endregion Time To Tick

    };
}