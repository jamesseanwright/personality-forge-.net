using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	public class Response
	{
		[DataMember(Name = "message")]
		public Message Message { get; set; }

		[DataMember(Name = "success")]
		public int Success { get; set; }

		[DataMember(Name = "errorMessage")]
		public string ErrorMessage { get; set; }
	}
}
