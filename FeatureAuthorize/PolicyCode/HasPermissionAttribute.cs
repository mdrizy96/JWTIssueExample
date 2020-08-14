using System;
using Microsoft.AspNetCore.Authorization;
using PermissionParts;

namespace FeatureAuthorize.PolicyCode
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permissions permission) : base(permission.ToString())
        { }
    }
}