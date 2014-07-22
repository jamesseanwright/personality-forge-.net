using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JamesWright.PersonalityForge.Interfaces
{
    internal interface IJsonHelper
    {
        string ToJson<T>(T obj);
        T ToObject<T>(string json);
    }
}
