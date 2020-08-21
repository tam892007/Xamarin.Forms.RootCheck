namespace Xamarin.Forms.RootCheck
{
    /// <summary>
    /// Interface to check if a device is rooted / jailbroken
    /// </summary>
    public interface IChecker
    {
        /// <summary>
        /// Check if the device is rooted / jailbroken
        /// </summary>
        /// <returns>true if rooted or jailbroken, false otherwise.</returns>
        bool IsDeviceRooted();
    }
}
