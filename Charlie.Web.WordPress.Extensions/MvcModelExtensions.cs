using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Charlie.Web.WordPress
{
    /// <summary>
    /// 
    /// </summary>
    public static class MvcModelExtensions
    {
        /// <summary>
        /// The prefix
        /// </summary>
        private const string Prefix = "prefix";

        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <param name="formValues">The form values.</param>
        /// <returns></returns>
        public static string GetPrefix(this FormCollection formValues)
        {
            return formValues[Prefix];
        }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllErrors(this ModelStateDictionary model)
        {
            return model == null ? null : (model.SelectMany(m => m.Value.Errors, (m, e) => e.ErrorMessage));
        }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllErrors(this System.Web.Http.ModelBinding.ModelStateDictionary model)
        {
            return model == null ? null : (model.SelectMany(m => m.Value.Errors, (m, e) => e.ErrorMessage));
        }

        /// <summary>
        /// Aggregates the specified spacher.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="spacher">The spacher.</param>
        /// <returns></returns>
        public static string Aggregate(this IEnumerable<string> source, char spacher = ',')
        {
            return source.Aggregate(string.Empty, (current, s) => current + (s + spacher));
        }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllErrors(this AggregateException error)
        {
            var errors = new List<string>();
            foreach (var e in error.InnerExceptions)
            {
                var msg = e.Message;
                var inner = e.InnerException;
                while (inner != null)
                {
                    msg += "->" + inner.Message;
                    inner = inner.InnerException;
                }
                errors.Add(msg);
            }
            return errors;
        }
    }
}