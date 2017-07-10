using System;
using NUnit.Framework;

namespace Xamarin.UITest.SpecFlow.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public partial class TasksFeature : BaseTestFixture
    {
        public TasksFeature(Platform platform)
            : base(platform)
        {
        }
    }
}
