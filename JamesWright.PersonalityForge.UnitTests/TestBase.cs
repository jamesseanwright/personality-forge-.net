using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace JamesWright.PersonalityForge.UnitTests
{
    public class TestBase
    {
        private object _instance;

        public TInstance GetInstance<TInstance>()
        {
            return (TInstance) _instance;
        }

        public void SetInstance(object obj)
        {
            _instance = obj;
        }

        public static TMock GenerateMock<TMock>() where TMock : class
        {
            return MockRepository.GenerateMock<TM>();
        }
    }
}
