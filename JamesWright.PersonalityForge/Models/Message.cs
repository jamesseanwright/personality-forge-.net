using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	public class Message
	{
		[DataMember(Name="message")]
		public string Text { get; set; }

		[DataMember(Name="chatBotID")]
		public int ChatBotId { get; set; }

		[DataMember(Name = "chatBotName")]
		public string ChatBotName { get; set; }

		[DataMember(Name="timestamp")]
		public int Timestamp { get; set; }
	}
}
