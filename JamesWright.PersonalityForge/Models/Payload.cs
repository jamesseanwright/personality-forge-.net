using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	class Payload
	{
		[DataMember(Name="message")]
		internal Message Message { get; set; }

		[DataMember(Name="user")]
		internal User User { get; set; }
	}
}

