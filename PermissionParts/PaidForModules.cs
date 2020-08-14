using System;

namespace PermissionParts
{
    /// <summary>
    /// This is an example of how you would manage what optional parts of your system a user can access
    /// NOTE: You can add Display attributes (as done on Permissions) to give more information about a module
    /// </summary>
    [Flags]
    public enum PaidForModules : long
    {
        None = 0,
        Feature1 = 1,
        Feature2 = 2,
        Feature3 = 4
    }
}
