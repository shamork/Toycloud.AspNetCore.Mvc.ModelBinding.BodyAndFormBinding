using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public static class BodyOrDefaultModelBinderProviderSetup
    {
        public static void InsertBodyOrDefaultBinding(this IList<IModelBinderProvider> providers)
        {
            var bodyProvider = providers.Single(provider => provider.GetType() == typeof(BodyModelBinderProvider)) as BodyModelBinderProvider;
            var complexProvider = providers.Single(provider => provider.GetType() == typeof(ComplexTypeModelBinderProvider)) as ComplexTypeModelBinderProvider;

            var bodyOrDefault = new BodyOrDefaultModelBinderProvider(bodyProvider, complexProvider);

            providers.Insert(0, bodyOrDefault);
        }
    }
}
