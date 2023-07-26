using System;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests_new
    {

        private LogAnalyzer analyzer = null;

        [SetUp]
        public void SetUpTest()
        {
            analyzer = new LogAnalyzer();
        }
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {


            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }



        [Test]
        [ExpectedException(typeof(AggregateException), ExpectedMessage = "filename has le ma be")]
        [Ignore("玩玩而已。")]
        public void IsValidLogFileName_EmptyFileName2_3()
        {

            bool result = analyzer.IsValidLogFileName2_3("filewithgoodextension.slf");

            Assert.True(result);
        }


        [Test]
        public void IsValidLogFileName_EmptyFileName2_3_1()
        {

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName2_3(""));

            //StringAssert.Contains("filename", ex.Message);

            Assert.That(ex.Message, Is.StringContaining("filename"));
        }

    }
}
