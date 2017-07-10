using System;
using NUnit.Framework;

namespace Xamarin.UITest.SpecFlow.Tests
{
    [TestFixture(Platform.iOS)]
    public partial class IOSOnlyFeature : BaseTestFixture
    {
        public IOSOnlyFeature(Platform platform)
            : base(platform)
        {
        }
    }
}
