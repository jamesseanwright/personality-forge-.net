using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Tests
{
    [TestClass]
    public class JsonHelperTests : TestBase
    {
        private ErrorService _errService;
        private readonly string _json;

        private const string PropValue = "hello";

        public JsonHelperTests()
        {
            _errService = new ErrorService();
            _json = string.Format("{{\"property\":\"{0}\"}}", PropValue);
        }

        [TestMethod]
        public void ItShouldConvertStringToObject()
        {
            JsonHelper instance = new JsonHelper(_errService);

            TestObject model = instance.ToObject<TestObject>(_json);

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.Property);
            Assert.AreEqual(PropValue, model.Property);
        }

        [TestMethod]
        public void ItShouldConvertObjectToString()
        {
            JsonHelper instance = new JsonHelper(_errService);
            TestObject model = new TestObject { Property = PropValue };

            string result = instance.ToJson<TestObject>(model);

            Assert.IsNotNull(result);
            Assert.AreEqual(_json, result);
        }

        [TestMethod]
        public void ItShouldHandleSerializationException()
        {
            bool isHandlerInvoked = false;

            _errService.CustomHandler += (ex, msg, fatal) =>
                {
                    isHandlerInvoked = true;
                };

            JsonHelper instance = new JsonHelper(_errService);

            TestObject oops = instance.ToObject<TestObject>("{{\"property\": he");

            Assert.IsTrue(isHandlerInvoked);
        }
    }

    [DataContract]
    class TestObject
    {
        [DataMember(Name="property")]
        public string Property { get; set; }
    }
}
