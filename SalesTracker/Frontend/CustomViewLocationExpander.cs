using Microsoft.AspNetCore.Mvc.Razor;

namespace Presentation
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //---------------------------------------------------------------------------------------------------
            // By default RazorViewEngine returns the following "viewLocations"
            //---------------------------------------------------------------------------------------------------
            // return new[]
            // {
            //     "/Views/{1}/{0}.cshtml",
            //     "/Views/Shared/{0}.cshtml"
            // };
            // return new[]
            // {
            //     "/Views/{controller}/{action}.cshtml",
            //     "/Views/Shared/{action}.cshtml"
            // };

            //---------------------------------------------------------------------------------------------------
            // We replace the default "viewLocations", pointing the RazorViewEngine where to look for the views
            //---------------------------------------------------------------------------------------------------
            return new[]
            {
                 "~/{1}/Views/{0}.cshtml",
                 "~/Shared/Views/{0}.cshtml",
             };
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Nothing needs to be done here
        }
    }
}
