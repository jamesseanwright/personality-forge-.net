using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesWright.PersonalityForge.Interfaces
{
    interface IJsonHelper
    {
        string ToJson<T>(T obj);
        T ToObject<T>(string json);
    }
}
