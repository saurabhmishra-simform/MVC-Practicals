using Microsoft.AspNetCore.Mvc.Filters;

namespace Practical10Task3.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class PartialCacheAttribute : Attribute, IActionFilter
    {
        private readonly int _duration;
        private readonly string _varyByParam;

        public PartialCacheAttribute(int duration, string varyByParam)
        {
            _duration = duration;
            _varyByParam = varyByParam;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the response is already cached
            if (context.HttpContext.Response.Headers.ContainsKey("Cache-Control"))
            {
                return;
            }

            // Set cache control headers
            var cacheControlValue = $"public, max-age={_duration}";
            context.HttpContext.Response.Headers.Add("Cache-Control", cacheControlValue);

            // Set vary by parameter headers
            if (!string.IsNullOrEmpty(_varyByParam))
            {
                context.HttpContext.Response.Headers.Add("Vary", _varyByParam);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed on action executed
        }
    }
}
