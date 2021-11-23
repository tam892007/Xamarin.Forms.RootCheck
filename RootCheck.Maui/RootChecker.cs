using RootCheck.Core;
using System;

namespace RootCheck.Maui
{
    /// <summary>
    /// Root Checker
    /// </summary>
    public static class RootChecker
    {
        private static Lazy<IChecker> platformImplementation = new Lazy<IChecker>(() => CreateChecker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Returns whether the device is rooted
        /// </summary>
        public static bool IsDeviceRooted
        {
            get
            {
                var checker = platformImplementation.Value;

                if (checker is null)
                    return false;

                return checker.IsDeviceRooted();
            }
        }

        private static IChecker CreateChecker()
        {
            return new PlatformChecker();
        }
    }
}
