using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public static class BodyAndFormModelBinderProviderSetup
    {
        public static void InsertBodyAndFormBinding(this IList<IModelBinderProvider> providers)
        {
            var bodyProvider = providers.Single(provider => provider.GetType() == typeof(BodyModelBinderProvider)) as BodyModelBinderProvider;
            var formProvider = providers.Single(provider => provider.GetType() == typeof(FormCollectionModelBinderProvider)) as FormCollectionModelBinderProvider;

            var BodyAndFormProvider = new BodyAndFormModelBinderProvider(bodyProvider, formProvider);

            providers.Insert(0, BodyAndFormProvider);
        }
    }
}
