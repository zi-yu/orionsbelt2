using NUnit.Framework;
using System;
using OrionsBelt.Generic;

namespace OrionsBeltTests.GenericTests
{
    [TestFixture]
    public class NumericUtilsTests
    {
        [Test]
        public void GetDouble_Fail_Exception()
        {
            try
            {
                string value = "11.22";
                NumericUtils.GetDouble(value, ",");
                Assert.Fail("Should send an exception");
            }catch(Exception){}
        }

        [Test]
        public void GetDouble_Sucess_WithPoint()
        {
            double control = 11.22;
            string value = "11.22";
            double ret = NumericUtils.GetDouble(value, ".");
            Assert.IsTrue(control == ret);
        }

        [Test]
        public void GetDouble_Sucess_Default()
        {
            double control = 11.22;
            string value = "11,22";
            double ret = NumericUtils.GetDouble(value);
            Assert.IsTrue(control == ret);
        }

        [Test]
        public void GetDecimalPart_Sucess()
        {
            double control = 11.22;
            int ret = NumericUtils.GetDecimalPart(control);
            Assert.IsTrue(ret == 22);
            control = 0.22342;
            ret = NumericUtils.GetDecimalPart(control);
            Assert.IsTrue(ret == 22342);
            control = 345345.22342;
            ret = NumericUtils.GetDecimalPart(control);
            Assert.IsTrue(ret == 22342);
        }
    }
}
