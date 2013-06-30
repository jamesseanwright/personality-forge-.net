using System;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge
{
	public static class PersonalityForge
	{
		private static APIInfo _apiInfo { get; set; }

		public static bool Initialise(string secret, string key, int botId)
		{
			_apiInfo = new APIInfo
			{
				Secret = secret,
				Key = key,
				BotId = botId
			};

			return true;
		}

		public static Response Send(string username, string message)
		{
			return PersonalityForgeDataService.Send(_apiInfo, username, message);
		}
	}
}

