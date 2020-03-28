using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromBodyAndFormAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BodyAndFormBindingSource.BodyAndForm;
    }
}
