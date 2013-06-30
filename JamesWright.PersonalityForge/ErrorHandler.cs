using System;
using System.Collections.Generic;

namespace JamesWright.PersonalityForge
{
	public static class ErrorService
	{
		private static Dictionary<string, string> _messages;

		public static Action<Exception, string, bool> CustomHandler { private get; set; }

		static ErrorService()
		{
			_messages = new Dictionary<string, string>();
			_messages.Add("deserialisation", "Could not create object from JSON response");
			_messages.Add("web", "Failed to retrieve data from the remote server");
			_messages.Add("general", "An error has occured");
			_messages.Add("response", "Couldn't create response. There's either a problem with the Personality Forge or this program requires an update.");
		}

		internal static void Handle(Exception e, string message, bool fatal)
		{
			string messageText;

			if (!_messages.TryGetValue (message, out messageText))
			{
				_messages.TryGetValue("general", out messageText);
			};

			if (CustomHandler != null)
			{
				CustomHandler(e, message, fatal);
			}
			else
			{
				Console.Error.WriteLine(string.Format("{0}: {1}.", messageText, e.Message));

				if (fatal)
				{
					Console.Error.WriteLine("This error was fatal. Exiting application!");
					Environment.Exit(1);
				}
			}
		}
	}
}

