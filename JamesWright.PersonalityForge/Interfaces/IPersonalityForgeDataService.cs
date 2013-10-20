using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesWright.PersonalityForge.Models;
using System.Threading.Tasks;

namespace JamesWright.PersonalityForge.Interfaces
{
    interface IPersonalityForgeDataService
    {
        Response Send(ApiInfo apiInfo, string username, string text);
        Task<Response> SendAsync(ApiInfo apiInfo, string username, string text);
    }
}
