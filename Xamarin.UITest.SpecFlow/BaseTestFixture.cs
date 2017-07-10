using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace Xamarin.UITest.SpecFlow
{
    public abstract class BaseTestFixture
    {
        protected BaseTestFixture(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppManager.StartApp();
        }
    }
}
