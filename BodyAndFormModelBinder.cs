using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyAndFormModelBinder : IModelBinder
    {
        private readonly IModelBinder _bodyBinder;
        private readonly IModelBinder _formBinder;

        public BodyAndFormModelBinder(IModelBinder bodyBinder, IModelBinder formBinder)
        {
            _bodyBinder = bodyBinder;
            _formBinder = formBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            return bindingContext.HttpContext.Request.HasFormContentType ? _formBinder.BindModelAsync(bindingContext) : _bodyBinder.BindModelAsync(bindingContext);
        }
    }
}
