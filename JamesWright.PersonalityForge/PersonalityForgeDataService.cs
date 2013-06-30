using System;
using System.Net;
using System.Text;
using System.Web;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge
{
	static class PersonalityForgeDataService
	{
		private const string _host = "http://www.personalityforge.com/api/chat/";
		private static WebClient _client;

		static PersonalityForgeDataService()
		{
			_client = new WebClient();
		}

		internal static Response Send(APIInfo apiInfo, string username, string text)
		{
			User user = new User
			{
				ExternalID = username
			};

			Message message = new Message
			{
				Text = text,
				Timestamp = Utils.GenerateTimestamp(),
				ChatBotId = apiInfo.BotId
			};

			Payload data = new Payload
			{
				Message = message,
				User = user
			};

			string dataJson = JsonHelper.ToJson<Payload> (data);
			string request = string.Format ("{0}?apiKey={1}&hash={2}&message={3}", _host, apiInfo.Key, Utils.GenerateSecret(apiInfo.Secret, dataJson), HttpUtility.UrlEncode(dataJson));

			try 
			{
				return JsonHelper.ToObject<Response>(MakeRequest(request));
			}
			catch (Exception e)
			{
				ErrorService.Handle(e, "response", false);
				return default(Response);
			}
		}

		private static string MakeRequest(string request)
		{
			byte[] response = null;

			try 
			{
				response = _client.DownloadData (new Uri (request));
			} 
			catch (WebException we) 
			{
				ErrorService.Handle(we, "web", true);
			} 
			catch (Exception e) 
			{
				ErrorService.Handle(e, "general", false);
			}

			try 
			{
				string resString = Encoding.UTF8.GetString(response);
				resString = Utils.FilterJson(resString);
				return resString;
			} 
			catch (Exception e) 
			{
				ErrorService.Handle(e, "general", false);
				return null;
			}
		}
	}
}