using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyOrDefaultModelBinderProvider : IModelBinderProvider
    {
        private BodyModelBinderProvider _bodyModelBinderProvider;
        private ComplexTypeModelBinderProvider _complexTypeModelBinderProvider;

        public BodyOrDefaultModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, ComplexTypeModelBinderProvider complexTypeModelBinderProvider)
        {
            _bodyModelBinderProvider = bodyModelBinderProvider;
            _complexTypeModelBinderProvider = complexTypeModelBinderProvider;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.BindingInfo.BindingSource != null && context.BindingInfo.BindingSource.CanAcceptDataFrom(BodyOrDefaultBindingSource.BodyOrDefault))
            {
                var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
                var complexBinder = _complexTypeModelBinderProvider.GetBinder(context);
                return new BodyOrDefaultModelBinder(bodyBinder, complexBinder);
            }
            return null;
        }
    }
}
