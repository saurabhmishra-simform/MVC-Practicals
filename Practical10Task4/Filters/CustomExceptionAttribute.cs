using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Practical10Task4.Filters
{
    public class CustomExceptionAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //Log exception
            //string controllerName = context.RouteData.Values["controller"].ToString();
            //string actionName = context.RouteData.Values["action"].ToString();
       
            if(context.Exception is DivideByZeroException)
            {
                //var model = new System.Web.Mvc.HandleErrorInfo(context.Exception, controllerName, actionName);
                context.Result = new ViewResult
                {
                    ViewName = "Error",
                    //ViewData = new ViewDataDictionary<System.Web.Mvc.HandleErrorInfo>(model),
                    //TempData = 
                };

            }
            context.ExceptionHandled = true;

        }
    }
}
