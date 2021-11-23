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
            return new PlatformChecker();
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
