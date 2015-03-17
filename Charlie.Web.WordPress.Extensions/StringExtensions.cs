using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Charlie.Web.WordPress
{
 public static   class StringExtensions
 {
     private static readonly Regex Md5ReplaceRegex = new Regex("-", RegexOptions.Compiled);
     private const string Empty = "";
     public static string Md5(this string source)
     {
         var md5 = MD5.Create();
         var inputBytes = Encoding.UTF8.GetBytes(source);
         var hash = md5.ComputeHash(inputBytes);
         return Md5ReplaceRegex.Replace(BitConverter.ToString(hash),Empty).ToLower().Substring(8,16);
     }
    }
}
