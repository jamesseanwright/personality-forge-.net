using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace JamesWright.PersonalityForge.Tests
{
    public class TestBase
    {
        public static TMock GenerateMock<TMock>() where TMock : class
        {
            return MockRepository.GenerateMock<TMock>();
        }
    }
}