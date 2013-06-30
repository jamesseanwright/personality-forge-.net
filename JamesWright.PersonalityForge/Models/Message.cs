using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	class Message
	{
		[DataMember(Name="message")]
		internal string Text { get; set; }

		[DataMember(Name="chatBotID")]
		internal int ChatBotId { get; set; }

		[DataMember(Name="timestamp")]
		internal int Timestamp { get; set; }
	}
}

