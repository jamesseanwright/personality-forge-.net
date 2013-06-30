/*
using System;
using NUnit.Framework;
using JamesWright.PersonalityForge;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge.UnitTests
{
	[TestFixture]
	public class JsonHelperTests
	{
		[Test]
		public void ToJson_Should_CreateStringFromObject()
		{
			string text = "Hello!";
			int integerValue = 1;

			Message message = new Message
			{
				Text = text,
				ChatBotId = integerValue,
				Timestamp = integerValue
			};

			string expectedJson = string.Format("{{\"chatBotID\":{0},\"message\":\"{1}\",\"timestamp\":{0}}}", integerValue, text);
			string actualJson = JsonHelper.ToJson(message);

			Assert.IsNotNull(actualJson);
			Assert.AreEqual(expectedJson, actualJson);
		}

		[Test]
		public void ToObject_Should_CreateObjectFromJson()
		{
			string text = "Hello!";
			int integerValue = 1;

			string json = string.Format("{{\"chatBotID\":{0},\"message\":\"{1}\",\"timestamp\":{0}}}", integerValue, text);

			Message expected = new Message
			{
				Text = text,
				ChatBotId = integerValue,
				Timestamp = integerValue
			};

			Message actual = JsonHelper.ToObject<Message>(json);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected.Text, actual.Text);
			Assert.AreEqual(expected.ChatBotId, actual.ChatBotId);
			Assert.AreEqual(expected.Timestamp, actual.Timestamp);
		}
	}
}

*/