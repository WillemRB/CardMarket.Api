using CardMarket.Api.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardMarket.Api.UnitTests
{
    [TestClass]
    public class StructsTests
    {
        [TestMethod]
        public void Language_FromId()
        {
            // Act
            var lang = Language.FromId(1);

            // Assert
            Assert.IsNotNull(lang);
            Assert.AreEqual("English", lang.ToString());
        }

        [TestMethod]
        public void Condition_FromId()
        {
            // Act
            var condition = Condition.FromId("LP");

            // Assert
            Assert.IsNotNull(condition);
            Assert.AreEqual("Light-played", condition.ToString());
        }
    }
}
