using RootCheck.Core;
using System;

namespace RootCheck.Maui
{
    // All the code in this file is only included on Android.
    public class AndroidRootChecker : IChecker
    {
        public bool IsDeviceRooted()
        {
            throw new NotImplementedException();
        }
    }
}