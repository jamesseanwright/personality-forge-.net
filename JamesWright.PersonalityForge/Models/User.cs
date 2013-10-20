using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	public class User
	{
		[DataMember(Name="externalID")]
		public string ExternalID;
	}
}

