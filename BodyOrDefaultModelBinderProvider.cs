using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyOrDefaultModelBinderProvider : IModelBinderProvider
    {
        private BodyModelBinderProvider _bodyModelBinderProvider;
        private ComplexTypeModelBinderProvider _complexTypeModelBinderProvider;
        private bool _replaceDefaultBinderGlobally;

        public BodyOrDefaultModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, ComplexTypeModelBinderProvider complexTypeModelBinderProvider, bool replaceDefaultBinderGlobally)
        {
            _bodyModelBinderProvider = bodyModelBinderProvider;
            _complexTypeModelBinderProvider = complexTypeModelBinderProvider;
            _replaceDefaultBinderGlobally = replaceDefaultBinderGlobally;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var canBind = false;
            if (_replaceDefaultBinderGlobally)
            {
                if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
                {
                    canBind = true;
                }
            }
            else if (context.BindingInfo.BindingSource != null && context.BindingInfo.BindingSource.CanAcceptDataFrom(BodyOrDefaultBindingSource.BodyOrDefault))
            {
                canBind = true;
            }
            if (canBind)
            {
                var shouldFakeBindingSource = context.BindingInfo.BindingSource == null;
                if (shouldFakeBindingSource)
                {
                    context.BindingInfo.BindingSource = BindingSource.Body;
                }
                var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
                if (shouldFakeBindingSource)
                {
                    context.BindingInfo.BindingSource = null;
                }
                var complexBinder = _complexTypeModelBinderProvider.GetBinder(context);
                return new BodyOrDefaultModelBinder(bodyBinder, complexBinder);
            }

            return null;
        }
    }
}
