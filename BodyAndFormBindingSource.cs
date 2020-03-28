using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Toycloud.AspNetCore.Mvc.ModelBinding
{
    public class BodyAndFormBindingSource : BindingSource
    {
        public static readonly BindingSource BodyAndForm = new BodyAndFormBindingSource(
            "BodyAndForm",
            "BodyAndForm",
            true,
            true
            );

        public BodyAndFormBindingSource(string id, string displayName, bool isGreedy, bool isFromRequest) : base(id, displayName, isGreedy, isFromRequest)
        {
        }

        public override bool CanAcceptDataFrom(BindingSource bindingSource)
        {
            return bindingSource == Body || bindingSource == Form || bindingSource == this;
        }
    }
}
