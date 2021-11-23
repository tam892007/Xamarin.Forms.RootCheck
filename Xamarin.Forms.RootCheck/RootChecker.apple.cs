using ObjCRuntime;
using RootCheck.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Xamarin.Forms.RootCheck
{
    /// <summary>
    /// iOS implementation of IChecker
    /// </summary>
    public class RootChecker : IChecker
    {
        private static readonly List<string> KnownDangerousFiles = new List<string>
            {
                "/Applications/Cydia.app",
                "/Applications/FakeCarrier.app",
                "/Applications/Icy.app",
                "/Applications/IntelliScreen.app",
                "/Applications/MxTube.app",
                "/Applications/RockApp.app",
                "/Applications/SBSettings.app",
                "/Applications/WinterBoard.app",
                "/Applications/blackra1n.app",
                "/Library/MobileSubstrate/DynamicLibraries/LiveClock.plist",
                "/Library/MobileSubstrate/DynamicLibraries/Veency.plist",
                "/Library/MobileSubstrate/MobileSubstrate.dylib",
                "/System/Library/LaunchDaemons/com.ikey.bbot.plist",
                "/System/Library/LaunchDaemons/com.saurik.Cydia.Startup.plist",
                "/private/var/tmp/cydia.log",
                "/etc/apt",
                "/usr/bin/sshd",
            };

        private static readonly List<string> KnownDangerousFolders = new List<string>
            {
                "/private/var/mobile/Library/SBSettings/Themes",
                "/etc/apt",
                "/private/var/lib/apt",
                "/var/cache/apt",
                "/var/lib/apt",
                "/private/var/lib/cydia",
                "/var/lib/cydia",
                "/private/var/stash",
            };

        /// <summary>
        /// Return true if the device is rooted/jailbroken
        /// </summary>
        /// <returns></returns>
        public bool IsDeviceRooted()
        {
            if (CheckPotentialDangerousFiles()
               || CheckPotentialDangerousFolders()
               || CheckFileWritePermission()
               || CanRunFork()
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check potential files which indicate a jailbreak
        /// </summary>
        /// <returns></returns>
        private bool CheckPotentialDangerousFiles()
        {
            foreach (var path in KnownDangerousFiles)
            {
                if (File.Exists(path))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///  Check potential folders which indicate a jailbreak
        /// </summary>
        /// <returns></returns>
        private bool CheckPotentialDangerousFolders()
        {
            foreach (var path in KnownDangerousFolders)
            {
                if (Directory.Exists(path))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Normal device will not allow to write to private folder
        /// </summary>
        /// <returns></returns>
        private bool CheckFileWritePermission()
        {
            //check write permission
            try
            {
                File.WriteAllText("/private/jailbreak.txt", "This is a test.");
                return true;
            }
            catch (UnauthorizedAccessException)
            {
            }

            return false;
        }

        /// <summary>
        /// equivalent of fork()
        /// </summary>
        /// <returns></returns>
        private bool CanRunFork()
        {
            try
            {
                //call fork function
                var forkPtr = Dlfcn.dlsym(Dlfcn.RTLD.Default, "fork");
                if (forkPtr != null)
                {
                    var fork = Marshal.GetDelegateForFunctionPointer<ForkCallbackDelegate>(forkPtr);
                    if (fork() != -1)
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }

        [MonoNativeFunctionWrapper]
        delegate int ForkCallbackDelegate();
    }
}
