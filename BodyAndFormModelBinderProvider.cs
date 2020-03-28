using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyAndFormModelBinderProvider : IModelBinderProvider
    {
        private BodyModelBinderProvider _bodyModelBinderProvider;
        private FormCollectionModelBinderProvider _formCollectionModelBinderProvider;

        public BodyAndFormModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, FormCollectionModelBinderProvider formCollectionModelBinderProvider)
        {
            _bodyModelBinderProvider = bodyModelBinderProvider;
            _formCollectionModelBinderProvider = formCollectionModelBinderProvider;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
            var formBinder = _formCollectionModelBinderProvider.GetBinder(context);

            if (context.BindingInfo.BindingSource != null
                && context.BindingInfo.BindingSource.CanAcceptDataFrom(BodyAndFormBindingSource.BodyAndForm))
            {
                return new BodyAndFormModelBinder(bodyBinder, formBinder);
            }
            else
            {
                return null;
            }
        }
    }
}
