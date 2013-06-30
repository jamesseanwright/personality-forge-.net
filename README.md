# Personality Forge .NET

A client side .NET library for the Personality Forge's Secure API.

## Usage

The two objects that'll permit you to make calls to the API are the `PersonalityForge` static class and the `Response` model (found in the `Models` namespace).

Once you've called the static class' `Initialise` method, taking your API secret, key, and the remote bot's ID, you can send messages to the API by calling `Send`. This simply takes a screen name and a message, and returns a `Response` object.

Here's the library's most basic usage within a C# command line application:

    using System;
    using JamesWright.PersonalityForge;
    using JamesWright.PersonalityForge.Models;
    
    namespace LibTest
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                if (PersonalityForge.Initialise("GP1R7xO2FIpRyzpQpgAR70B0iCAr3Nbf", "eqTSixwhSC3GJ5QZ", 93127))
                {
                    Console.WriteLine("Enter a message:");
                    string message = Console.ReadLine();
                    Response response = PersonalityForge.Send("james", message);
                    Console.WriteLine("{0} says \"{1}\"", response.ChatBotName, response.Message);
                }
            }
        }
    }

## Unit tests

There are some unit tests for this project, but they need to be rewritten as the library originates from another project. 

