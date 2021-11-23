using RootCheck.Core;
using System;

namespace RootCheck.Maui
{
    public static class RootChecker
    {
        private static Lazy<IChecker> platformImplementation = new Lazy<IChecker>(() => CreateChecker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static bool IsDeviceRooted()
        {
            var checker = platformImplementation.Value;

            if (checker is null)
                return false;

            return checker.IsDeviceRooted();
        }

        private static IChecker CreateChecker()
        {
            return new PlatformChecker();
        }
    }
}
