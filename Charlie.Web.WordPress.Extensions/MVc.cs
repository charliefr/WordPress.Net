using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Charlie.Web.WordPress
{
    public static  class EditorExtensions
    {
        public static MvcHtmlString DisplayWaterMarkFor<TModel, TValue>(this HtmlHelper<TModel> html,
           Expression<Func<TModel, TValue>> expression)
       {
          return  MvcHtmlString.Create(ModelMetadata.FromLambdaExpression(expression, html.ViewData).Watermark);
       }

        public static MvcHtmlString DisplayDescriptionFor<TModel, TValue>(this HtmlHelper<TModel> html,
       Expression<Func<TModel, TValue>> expression)
       {
           return MvcHtmlString.Create(ModelMetadata.FromLambdaExpression(expression, html.ViewData).Description);
       }
    }
}
