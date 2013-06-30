using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JamesWright.PersonalityForge
{
	static class Utils
	{
		internal static string GenerateSecret(string secret, string data)
		{
			HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
			byte[] messageBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(data));
			
			StringBuilder builder = new StringBuilder();
			
			foreach (byte chunk in messageBytes)
			{
				builder.Append(chunk.ToString("x2"));
			}
			
			return builder.ToString();
		}
		
		internal static int GenerateTimestamp()
		{
			long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
			ticks /= 10000000;
			return (int)ticks;
		}

		internal static string FilterJson(string text)
		{
			const string delimiter = "cess\":1,\"errorMessage\":\"\",\"message\":";
			string returnValue = text.Substring(text.LastIndexOf(delimiter) + delimiter.Length);
			return returnValue.Substring(0, returnValue.Length - 1);
		}
	}
}

