using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.PersonalityForge
{
    public class PersonalityForgeException : Exception
    {
        public PersonalityForgeException() { }

        public PersonalityForgeException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
