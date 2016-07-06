using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MillisecondsSince19700101.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMillisecondsSince19700101()
        {
            long milliseconds = 1433254652877;
            DateSince19700101 dateSince19700101 = new DateSince19700101(milliseconds);
            DateTime datetime1 = dateSince19700101.GetDateTime();

            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dateTimeExpected = dateTime.AddMilliseconds(milliseconds);

            Assert.AreEqual(dateTimeExpected, datetime1);
        }
    }
}
