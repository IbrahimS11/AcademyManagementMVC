using Microsoft.AspNetCore.Mvc.Filters;

namespace Instructors.Filters
{
    public class HandleErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = $"<h1 style='color:red'>Something went wrong , Please try again later </h1><br/><h3 style='color:blue'>{context.Exception.Message}</h3>";
            //context.Result = contentResult;

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            context.Result = viewResult;
           
        }
    }
}
