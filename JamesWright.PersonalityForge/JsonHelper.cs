using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using JamesWright.PersonalityForge.Interfaces;

namespace JamesWright.PersonalityForge
{
    public class JsonHelper : IJsonHelper
	{
        private IErrorService _errorService;

        public JsonHelper()
        {
            _errorService = new ErrorService();
        }

        // constructor for dependency injection
        public JsonHelper(IErrorService errorService)
        {
            _errorService = errorService;
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
			catch (SerializationException se)
			{
                _errorService.Handle(se, "deserialisation", true);
				return default(T);
			}
			catch (Exception e)
			{
                _errorService.Handle(e, "general", false);
				return default(T);
			}
		}
	}
}

