using System;
using JamesWright.PersonalityForge.Models;
using JamesWright.PersonalityForge.Interfaces;
using System.Threading.Tasks;

namespace JamesWright.PersonalityForge
{
	public class PersonalityForge : IPersonalityForge
	{
		private ApiInfo _apiInfo;
        private IPersonalityForgeDataService _dataService;

        public IErrorService ErrorService { get; set; }

        public PersonalityForge(string secret, string key, int botId)
        {
            _apiInfo = new ApiInfo
            {
                Secret = secret,
                Key = key,
                BotId = botId
            };

            ErrorService = new ErrorService();
            _dataService = new PersonalityForgeDataService(new JsonHelper(), ErrorService);
        }

        //constructor for injecting dependencies
        PersonalityForge(IPersonalityForgeDataService dataService, IErrorService errorService)
        {
            _dataService = dataService;
            ErrorService = errorService;
        }

		public Response Send(string username, string message)
		{
            return _dataService.Send(_apiInfo, username, message);
		}

        public async Task<Response> SendAsync(string username, string message)
        {
            Response response = await _dataService.SendAsync(_apiInfo, username, message);
            return response;
        }
	}
}

