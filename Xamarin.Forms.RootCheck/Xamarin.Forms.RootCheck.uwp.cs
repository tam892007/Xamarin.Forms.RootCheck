namespace Xamarin.Forms.RootCheck
{
    /// <summary>
    /// UWP implementation of IChecker
    /// </summary>
    public class RootChecker : IChecker
    {
        /// <summary>
        /// Check if the device is rooted / jailbroken
        /// </summary>
        /// <returns>true if rooted or jailbroken, false otherwise.</returns>
        public bool IsDeviceRooted()
        {
            //no check on windows phone.
            return false;
        }
    }
}
