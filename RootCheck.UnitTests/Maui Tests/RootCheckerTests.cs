using NUnit.Framework;
using RootCheck.Maui;

namespace RootCheck.UnitTests
{
    public class RootCheckerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsDeviceRooted_PlatformNotSupported_Should_ReturnFalse()
        {
            var rooted = RootChecker.IsDeviceRooted;

            Assert.False(rooted, "Root check is not supported by platform, it should not be able to detect a root");
        }

        // TODO: Is it possible to test anything else?
    }
}