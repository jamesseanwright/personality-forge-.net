# Personality Forge.NET

A client side .NET library for [The Personality Forge](http://www.personalityforge.com/)'s Secure API.

## Usage

The two objects that'll permit you to use the API are the `PersonalityForge` static class and the `Response` model (found in the `Models` namespace).

Once you've called the static class' `Initialise` method, taking your API secret, key, and the remote bot's ID, you can send messages to the API by calling `Send`. This simply takes a screen name and a message, and returns a `Response` object.

Here's the library's most basic usage within a C# command line application:

    using System;
    using JamesWright.PersonalityForge;
    using JamesWright.PersonalityForge.Models;
    
    namespace LibTest
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                if (PersonalityForge.Initialise(<API Secret>, <API Key>, <Chatbot ID>))
                {
                    Console.WriteLine("Enter a message:");
                    string message = Console.ReadLine();
                    Response response = PersonalityForge.Send("james", message);
                    Console.WriteLine("{0} says \"{1}\"", response.ChatBotName, response.Message);
                }
            }
        }
    }

## Error handling

The `JamesWright.PersonalityForge` namespace contains a static `ErrorService` class, used to handle errors throughout the invocation of the library. By default, this uses the `Console.Error` TextWriter, but since the .NET stack is ridiculously diverse, it's possible to specify your own error handler.

The `CustomHandler` property allows you to specify your own error handler, using an `Action` object. This property will return the exception, a library-specific message, and a boolean to identify the error as fatal.

A custom error handler can be specified like this:

    ErrorService.CustomHandler = (ex, message, fatal) =>
    {
        // awesome logic
    };

## Unit tests

There are some unit tests for this project, but they need to be rewritten as the library originates from another project. 

## TODO

* Use regex to extract JSON from crappy API response
* Utilise the API response's error data
