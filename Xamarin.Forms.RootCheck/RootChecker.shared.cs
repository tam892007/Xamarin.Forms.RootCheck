﻿using RootCheck.Core;
using System;

namespace Xamarin.Forms.RootCheck
{
    /// <summary>
    /// Root Check
    /// </summary>
    public static class RootCheck
    {
        static Lazy<IChecker> implementation = new Lazy<IChecker>(() => CreateChecker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Returns whether the device is rooted
        /// </summary>
        public static bool IsDeviceRooted
        {
            get
            {
                IChecker checker = implementation.Value;

                if (checker is null)
                {
                    throw NotImplementedInReferenceAssembly();
                }

                return checker.IsDeviceRooted();
            }
        }

        static IChecker CreateChecker()
        {
        #if NETSTANDARD1_0 || NETSTANDARD2_0
                    return null;
        #else
        #pragma warning disable IDE0022 // Use expression body for methods
                return new Xamarin.Forms.RootCheck.RootChecker();
        #pragma warning restore IDE0022 // Use expression body for methods
        #endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
