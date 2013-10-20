# Personality Forge.NET

A client side .NET library for [The Personality Forge](http://www.personalityforge.com/)'s Secure API.

## Usage

The two objects that'll permit you to use the API are the `PersonalityForge` class and the `Response` model (found in the `Models` namespace).

Once you've created an instance of`PersonalityForge`, passing your API secret, key, and the remote bot's ID to its constructor, you can send messages to the API by calling `Send`. This simply takes a screen name and a message, and returns a `Response` object.

Here's the library's usage within a C# command line application:

    class Program
    {
	//the IPersonalityForge interface is available publicly if you want to mock it in your unit tests! 
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

## Error handling

The `PersonalityForge` class contains a `ErrorService` property, used to handle errors throughout the invocation of the library. By default, this uses the `Console.Error` TextWriter, but since the .NET stack is ridiculously diverse, it's possible to specify your own error handler.

The `CustomHandler` property allows you to specify your own error handler, using an `Action` object. This property will return the exception, a library-specific message, and a boolean to identify the error as fatal.

A custom error handler can be specified like this:

    _personalityForge.ErrorService.CustomHandler += (ex, message, fatal) =>
                {
                    //awesome logic
                };

## Asynchronous usage

The library also supports asynchronous calls to the service, using .NET 4.5's async/await syntax:

	Response response = await _personalityForge.SendAsync(username, message);

See the `JamesWright.PersonalityForge.WpfExample` WPF program to see how asynchronous usage avoids disruption of the main thread of execution.

## Unit tests

There are some unit tests for this project, but they need to be rewritten as the library originates from another project. 
