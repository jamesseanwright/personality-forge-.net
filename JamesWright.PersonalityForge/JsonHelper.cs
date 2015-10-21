using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using JamesWright.PersonalityForge.Interfaces;
using System.Runtime.CompilerServices;

namespace JamesWright.PersonalityForge
{
	internal class JsonHelper : IJsonHelper
	{
		public JsonHelper()
		{
		}


		public string ToJson<T>(T obj)
		{
			DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(T));
			
			MemoryStream stream = new MemoryStream();
			serialiser.WriteObject(stream, obj);
			
			return Encoding.UTF8.GetString(stream.ToArray());
		}

		public T ToObject<T>(string json)
		{
			DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(T));
			byte[] jBytes = Encoding.UTF8.GetBytes(json);
			
			MemoryStream stream = new MemoryStream(jBytes);
			
			try 
			{
				return (T)serialiser.ReadObject(stream);
			}
			catch (Exception e)
			{
				throw new PersonalityForgeException(e.Message, e);
			}
		}
	}
}
