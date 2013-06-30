/*
using System;
using NUnit.Framework;

namespace PersonalityForgeCLI.UnitTests
{
	[TestFixture]
	public class UtilsTests
	{
		[Test]
		public void GenerateTimestamp_Should_ReturnCurrentDate()
		{
			int timestamp = Utils.GenerateTimestamp();
			DateTime now = DateTime.UtcNow;
			DateTime actual = DateTime.Parse("01/01/1970 00:00:00").AddSeconds(timestamp);

			Assert.IsNotNull(timestamp);
			Assert.AreEqual(now.ToShortDateString(), actual.ToShortDateString());
		}

		[Test]
		public void GenerateSecret_Should_CreateCorrectHash()
		{
			string data = "some json";
			string expected = "ba138853cd0400683b66eb24cd45fee722d794600190779702253652148a118f";
			string hash = Utils.GenerateSecret(data);

			Assert.IsNotNull(hash);
			Assert.AreEqual(expected, hash);
		}

		[Test]
		public void FilterJson_Should_ExtractResponseMessage()
		{
			string innerJson = "{\"chatBotID\": 1, \"message\": \"lol\"}";
			string response = string.Format("<br><br>HTML in an API response :(<br>{{ \"success\":1,\"errorMessage\":\"\",\"message\":{0}}}", innerJson);

			string actual = Utils.FilterJson(response);

			Assert.IsNotNull(actual);
			Assert.AreEqual(innerJson, actual);
		}
	}
}

*/