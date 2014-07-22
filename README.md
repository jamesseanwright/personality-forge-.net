# Personality Forge.NET

A .NET library for [The Personality Forge](http://www.personalityforge.com/)'s Secure API.

## Usage

The latest release build is available via [NuGet](https://www.nuget.org/packages/JamesWright.PersonalityForge/), or in [this](https://github.com/jamesseanwright/personality-forge-.net/tree/master/JamesWright.PersonalityForge/bin/Release) repo folder.

The 3 classes that'll permit you to use the API are `PersonalityForge`, `Message`, and `Response` (the last two being located in the `Models` namespace).

Once you've created an instance of`PersonalityForge`, passing your API secret, key, and the remote bot's ID to its constructor, you can send messages to the API by calling `Send`. This simply takes a screen name and a message, and returns a `Response` object.

Here's the library's usage within a C# command line application:

    class Program
    {
        /*the IPersonalityForge interface is available publicly
         *in the namespace JamesWright.PersonalityForge.Interfaces
         *if you want to mock it in your unit tests!*/
        private static IPersonalityForge _personalityForge;

        static void Main(string[] args)
        {
            _personalityForge = new PersonalityForge(<API Secret>, <API Key>, <Bot ID>);

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

Any exception thrown by the library will be of type `PersonalityForgeException`. This derives from `System.Exception`, thus you can get the `InnerException` property to determine the underlying exception:

    try
	{
	    Response response = _personalityForge.Send(username, message);
	}
	catch (PersonalityForgeException e)
	{
		Console.WriteLine(e.Message);
	}

## Asynchronous usage

The library also supports asynchronous calls to the service, using .NET 4.5's async/await syntax:

	Response response = await _personalityForge.SendAsync(username, message);

See the `JamesWright.PersonalityForge.WpfExample` WPF program to see how asynchronous usage avoids disruption of the main thread of execution.

## Unit tests

There are currently a handful of unit tests. There are more on the way!
