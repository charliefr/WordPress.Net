using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Charlie.Web.WordPress
{
   public static  class ModelExtensions
   {
       private const string Prefix = "prefix";

       public static string GetPrefix(this System.Web.Mvc.FormCollection formValues)
       {
           return formValues[Prefix];
       }

       public static IEnumerable<string> GetAllErrors(this System.Web.Mvc.ModelStateDictionary model)
       {
           return model == null ? null : (model.SelectMany(m => m.Value.Errors, (m, e) => e.ErrorMessage));
       }

       public static IEnumerable<string> GetAllErrors(this System.Web.Http.ModelBinding.ModelStateDictionary model)
       {
           return model == null ? null : (model.SelectMany(m => m.Value.Errors, (m, e) => e.ErrorMessage));
       }

       public static string Aggregate(this IEnumerable<string> source, char spacher = ',')
       {
           return source.Aggregate(string.Empty, (current, s) => current + (s + spacher));
       }

       public static IEnumerable<string> GetAllErrors(this AggregateException error)
       {
           List<string> errors = new List<string>();
           foreach (var e in error.InnerExceptions)
           {
               var msg = e.Message;
               var inner = e.InnerException;
               while (inner!=null)
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
