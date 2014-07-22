using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.PersonalityForge.Tests
{
    [TestClass]
    public class UtilsTests : TestBase
    {
        [TestMethod]
        public void ItShouldGenerateCorrectSecret()
        {
            string secret = "secret",
                data = "data";

            HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            byte[] messageBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder builder = new StringBuilder();

            foreach (byte chunk in messageBytes)
            {
                builder.Append(chunk.ToString("x2"));
            }

            Utils instance = new Utils();
            string expectedSecret = builder.ToString(),
                actualSecret = instance.GenerateSecret(secret, data);

            Assert.AreEqual(expectedSecret, actualSecret);
        }

        [TestMethod]
        public void ItShouldFilterJsonFromBadResponseText()
        {
            Utils instance = new Utils();

            string response = "some stuff!!! {\"success\": true}",
                expectedJson = "{\"success\": true}",
                actualJson = instance.FilterJson(Encoding.UTF8.GetBytes(response));

            Assert.AreEqual(expectedJson, actualJson);
        }

        [TestMethod]
        [ExpectedException(typeof(PersonalityForgeException))]
        public void ItShouldThrowAnExceptionWhenResponseIsNull()
        {
            Utils instance = new Utils();
            instance.FilterJson(null);
        }
    }
}
