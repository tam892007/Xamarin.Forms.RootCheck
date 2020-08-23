# Xamarin.Forms.RootCheck

A Xamarin Forms plugin to check if devices are rooted / jailbroken.

**Android checks**

* DetectRootManagementApps
* DetectRootCloakingApps
* DetectPotentiallyDangerousApps
* CheckTestKey
* CheckForBinary(BINARY_MAGISK)
* CheckForBinary(BINARY_SU)
* CheckForBinary(BINARY_BUSYBOX)
* CheckSUExists()

**iOS checks**

* CheckPotentialDangerousFiles
* CheckPotentialDangerousFolders
* CheckFileWritePermission
* CanRunFork

## Usage

```C#
using Xamarin.Forms.RootCheck;
```
```C#
var isRooted = RootCheck.Current.IsDeviceRooted();
```

### Credits to

* Prempal Singh and others from this popular library: [RootBeer](https://github.com/scottyab/rootbeer)
