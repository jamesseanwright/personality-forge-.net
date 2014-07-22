using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Tests
{
    [TestClass]
    public class JsonHelperTests : TestBase
    {
        private readonly string _json;

        private const string PropValue = "hello";

        public JsonHelperTests()
        {
            _json = string.Format("{{\"property\":\"{0}\"}}", PropValue);
        }

        [TestMethod]
        public void ItShouldConvertStringToObject()
        {
            JsonHelper instance = new JsonHelper();

            TestObject model = instance.ToObject<TestObject>(_json);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Property);
            Assert.AreEqual(PropValue, model.Property);
        }

        [TestMethod]
        public void ItShouldConvertObjectToString()
        {
            JsonHelper instance = new JsonHelper();
            TestObject model = new TestObject { Property = PropValue };

            string result = instance.ToJson<TestObject>(model);

            Assert.IsNotNull(result);
            Assert.AreEqual(_json, result);
        }

        [TestMethod]
        [ExpectedException(typeof (PersonalityForgeException))]
        public void ItShouldHandleSerializationException()
        {
            JsonHelper instance = new JsonHelper();
            TestObject oops = instance.ToObject<TestObject>("{{\"property\": he");
        }
    }

    [DataContract]
    class TestObject
    {
        [DataMember(Name="property")]
        public string Property { get; set; }
    }
}
