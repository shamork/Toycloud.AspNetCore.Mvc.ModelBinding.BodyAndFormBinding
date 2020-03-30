using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyOrDefaultModelBinder : IModelBinder
    {
        private readonly IModelBinder _bodyBinder;
        private readonly IModelBinder _complexBinder;

        public BodyOrDefaultModelBinder(IModelBinder bodyBinder, IModelBinder complexBinder)
        {
            _bodyBinder = bodyBinder;
            _complexBinder = complexBinder;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await _bodyBinder.BindModelAsync(bindingContext);

            if (bindingContext.Result.IsModelSet)
            {
                return;
            }
            bindingContext.ModelState.Clear();
            await _complexBinder.BindModelAsync(bindingContext);
        }
    }
}
