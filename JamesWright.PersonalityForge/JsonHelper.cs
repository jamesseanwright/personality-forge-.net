using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

namespace JamesWright.PersonalityForge
{
	static class JsonHelper
	{
		internal static string ToJson<T>(T obj)
		{
			DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(T));
			
			MemoryStream stream = new MemoryStream();
			serialiser.WriteObject(stream, obj);
			
			return Encoding.UTF8.GetString(stream.ToArray());
		}
		
		internal static T ToObject<T>(string json)
		{
			DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(T));
			byte[] jBytes = Encoding.UTF8.GetBytes(json);
			
			MemoryStream stream = new MemoryStream(jBytes);
			
			try 
			{
				return (T)serialiser.ReadObject(stream);
			} 
			catch (SerializationException se)
			{
				ErrorService.Handle(se, "deserialisation", true);
				return default(T);
			}
			catch (Exception e)
			{
				ErrorService.Handle(e, "general", false);
				return default(T);
			}
		}
	}
}

