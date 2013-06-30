using System;
using System.Runtime.Serialization;

namespace JamesWright.PersonalityForge.Models
{
	[DataContract]
	class User
	{
		[DataMember(Name="externalID")]
		internal string ExternalID;
	}
}

