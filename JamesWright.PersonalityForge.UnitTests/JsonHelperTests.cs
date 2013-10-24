using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JamesWright.PersonalityForge.UnitTests
{
    [TestFixture]
    public class JsonHelperTests : TestBase
    {
        [SetUp]
        public void CreateInstance()
        {
            SetInstance(new JsonHelper());
        }

        [Test]
        public void ItShouldConvertStringToJson()
        {
            
        }
    }
}
