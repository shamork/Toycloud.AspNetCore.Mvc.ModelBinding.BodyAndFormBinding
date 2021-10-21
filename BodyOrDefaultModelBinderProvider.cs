﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
#if NET5_0_OR_GREATER
using ComplexDataModelBinderProvider = Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexObjectModelBinderProvider;
#else
using ComplexDataModelBinderProvider = Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinderProvider;
#endif

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyOrDefaultModelBinderProvider : IModelBinderProvider
    {
        private BodyModelBinderProvider _bodyModelBinderProvider;
        private ComplexDataModelBinderProvider _complexDataModelBinderProvider;

        public BodyOrDefaultModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, ComplexDataModelBinderProvider complexDataModelBinderProvider)
        {
            _bodyModelBinderProvider = bodyModelBinderProvider;
            _complexDataModelBinderProvider = complexDataModelBinderProvider;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.BindingInfo.BindingSource != null && context.BindingInfo.BindingSource.CanAcceptDataFrom(BodyOrDefaultBindingSource.BodyOrDefault))
            {
                var bodyBinder = _bodyModelBinderProvider.GetBinder(context);
                var complexBinder = _complexDataModelBinderProvider.GetBinder(context);
                return new BodyOrDefaultModelBinder(bodyBinder, complexBinder);
            }
            return null;
        }
    }
}
