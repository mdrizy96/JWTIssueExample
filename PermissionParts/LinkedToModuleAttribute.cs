using System;

namespace PermissionParts
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LinkedToModuleAttribute : Attribute
    {
        public PaidForModules PaidForModule { get; private set; }

        public LinkedToModuleAttribute(PaidForModules paidForModule)
        {
            PaidForModule = paidForModule;
        }
    }
}