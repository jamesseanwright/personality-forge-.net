using System;
using System.Net;
using System.Text;
using System.Web;
using JamesWright.PersonalityForge.Models;
using JamesWright.PersonalityForge.Interfaces;
using System.Threading.Tasks;

namespace JamesWright.PersonalityForge
{
	class PersonalityForgeDataService : IPersonalityForgeDataService
	{
		private const string _host = "http://www.personalityforge.com/api/chat/";
		private WebClient _client;
        private IJsonHelper _jsonHelper;
        private IErrorService _errorService;

		internal PersonalityForgeDataService()
		{
			_client = new WebClient();
            _jsonHelper = new JsonHelper();
            _errorService = new ErrorService();
		}

        //constructor for dependency injection
        internal PersonalityForgeDataService(IJsonHelper jsonHelper, IErrorService errorService)
        {
            _client = new WebClient();
            _jsonHelper = jsonHelper;
            _errorService = errorService;
        }

        Response IPersonalityForgeDataService.Send(ApiInfo apiInfo, string username, string text)
		{
            Message message = CreateMessage(text, apiInfo.BotId);
            User user = CreateUser(username);

            Payload data = CreatePayload(message, user);

			string dataJson = _jsonHelper.ToJson<Payload>(data);
            string request = GetRequestUri(apiInfo, dataJson);

			try 
			{
                return _jsonHelper.ToObject<Response>(MakeRequest(request));
			}
			catch (Exception e)
			{
				_errorService.Handle(e, "response", false);
                return null;
			}
		}

        async Task<Response> IPersonalityForgeDataService.SendAsync(ApiInfo apiInfo, string username, string text)
        {
            Message message = CreateMessage(text, apiInfo.BotId);
            User user = CreateUser(username);

            Payload data = CreatePayload(message, user);

            string dataJson = _jsonHelper.ToJson<Payload>(data);
            string request = GetRequestUri(apiInfo, dataJson);

            try
            {
                string responseJson = await MakeRequestAsync(request);
                return _jsonHelper.ToObject<Response>(responseJson);
            }
            catch (Exception e)
            {
                _errorService.Handle(e, "response", false);
                return null;
            }
        }

		private string MakeRequest(string request)
		{
			byte[] response = null;

			try 
			{
				response = _client.DownloadData(new Uri(request));
			} 
			catch (WebException we) 
			{
				_errorService.Handle(we, "web", true);
			} 
			catch (Exception e) 
			{
                _errorService.Handle(e, "general", false);
			}

            return response != null ? FilterJson(response) : null;
		}

        private async Task<string> MakeRequestAsync(string request)
        {
            byte[] response = null;

            try
            {
                response = await _client.DownloadDataTaskAsync(new Uri(request));
            }
            catch (WebException we)
            {
                _errorService.Handle(we, "web", true);
            }
            catch (Exception e)
            {
                _errorService.Handle(e, "general", false);
            }

            return response != null ? FilterJson(response) : null;
        }

        private User CreateUser(string username)
        {
            return new User
            {
                ExternalID = username
            };
        }

        private Message CreateMessage(string text, int botId)
        {
            return new Message
            {
                Text = text,
                Timestamp = Utils.GenerateTimestamp(),
                ChatBotId = botId
            };
        }

        private Payload CreatePayload(Message message, User user)
        {
            return new Payload
            {
                Message = message,
                User = user
            };
        }

        private string GetRequestUri(ApiInfo apiInfo, string dataJson)
        {
            return string.Format("{0}?apiKey={1}&hash={2}&message={3}", _host, apiInfo.Key, Utils.GenerateSecret(apiInfo.Secret, dataJson), HttpUtility.UrlEncode(dataJson));
        }

        private string FilterJson(byte[] response)
        {
            try
            {
                string resString = Encoding.UTF8.GetString(response);
                resString = Utils.FilterJson(resString);
                return resString;
            }
            catch (Exception e)
            {
                _errorService.Handle(e, "general", false);
                return null;
            }
        }
	}
}