using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromBodyOrDefaultAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BodyOrDefaultBindingSource.BodyOrDefault;
    }
}
