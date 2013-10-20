using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge.Interfaces
{
    public interface IPersonalityForge
    {
        IErrorService ErrorService { get; set; }
        Response Send(string username, string message);
        Task<Response> SendAsync(string username, string message);
    }
}
