using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Charlie.Web.WordPress
{
    /// <summary>
    /// 
    /// </summary>
    public static class MvcEditorExtensions
    {
        /// <summary>
        /// Displays the water mark for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString DisplayWaterMarkFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return MvcHtmlString.Create(ModelMetadata.FromLambdaExpression(expression, html.ViewData).Watermark);
        }
        /// <summary>
        /// Displays the description for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString DisplayDescriptionFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return MvcHtmlString.Create(ModelMetadata.FromLambdaExpression(expression, html.ViewData).Description);
        }
    }
}