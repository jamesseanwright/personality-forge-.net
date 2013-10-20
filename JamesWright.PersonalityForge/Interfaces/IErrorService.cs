using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesWright.PersonalityForge.Interfaces
{
    public interface IErrorService
    {
        Action<Exception, string, bool> CustomHandler { get; set; }
        void Handle(Exception e, string message, bool fatal);
    }
}
