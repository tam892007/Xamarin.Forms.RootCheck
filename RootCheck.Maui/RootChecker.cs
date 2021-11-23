using RootCheck.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootCheck.Maui
{
    public static class RootChecker
    {
        private static Lazy<IChecker> platformImplementation = new Lazy<IChecker>(() => CreateChecker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static bool IsDeviceRooted()
        {
            var checker = platformImplementation.Value;

            if (checker is null)
            {
                throw NotImplementedInReferenceAssembly();
            }

            return checker.IsDeviceRooted();
        }

        private static IChecker CreateChecker()
        {
            // TODO: Do we need to care about this anymore?
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new PlatformChecker();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
