using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	public class Response
	{
		[DataMember(Name="chatBotName")]
		public string ChatBotName { get; set; }

		[DataMember(Name="message")]
		public string Message { get; set; }
	}
}

