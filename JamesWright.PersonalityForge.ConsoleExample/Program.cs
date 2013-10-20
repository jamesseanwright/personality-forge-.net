using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesWright.PersonalityForge;
using JamesWright.PersonalityForge.Interfaces;
using JamesWright.PersonalityForge.Models;

namespace JamesWright.PersonalityForge.ConsoleExample
{
    class Program
    {
        private static IPersonalityForge _personalityForge;

        static void Main(string[] args)
        {
            _personalityForge = new PersonalityForge("GP1R7xO2FIpRyzpQpgAR70B0iCAr3Nbf", "eqTSixwhSC3GJ5QZ", 93127);

            Console.Write("Enter a username: ");
            string username = Console.ReadLine();
            Converse(username);
        }

        static void Converse(string username)
        {
            Console.Write("\nEnter a message!\n");

            Response response;

            while (true)
            {
                Console.Write(">");
                string message = Console.ReadLine();
                response = _personalityForge.Send(username, message);
                Console.WriteLine("{0}: {1}", response.Message.ChatBotName, response.Message.Text);
            }
        }
    }
}
