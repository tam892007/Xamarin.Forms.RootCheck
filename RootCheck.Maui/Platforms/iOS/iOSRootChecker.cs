using RootCheck.Core;
using System;

namespace RootCheck.Maui
{
    // All the code in this file is only included on iOS.
    public class iOSRootChecker : IChecker
    {
        public bool IsDeviceRooted()
        {
            throw new NotImplementedException();
        }
    }
}