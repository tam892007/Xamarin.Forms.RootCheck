using RootCheck.Core;

namespace RootCheck.Maui
{
    /// <summary>
    /// Root Checker
    /// </summary>
    public class RootChecker : IChecker
    {
        public bool IsDeviceRooted()
        {
            var checker = GetPlatformChecker();

            if (checker is null)
                return false;

            return checker.IsDeviceRooted();
        }

        private IChecker GetPlatformChecker()
        {
#if IOS
            return new iOSRootChecker();
#endif

#if ANDROID
            return new AndroidRootChecker();
#endif

            // Default if the platform is not supported
            return null;
        }
    }
}