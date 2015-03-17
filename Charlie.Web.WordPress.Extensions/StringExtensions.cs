using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Charlie.Web.WordPress
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The empty
        /// </summary>
        private const string Empty = "";
        /// <summary>
        /// The MD5 replace regex
        /// </summary>
        private static readonly Regex Md5ReplaceRegex = new Regex("-", RegexOptions.Compiled);
        /// <summary>
        /// MD5s the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string Md5(this string source)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(source);
            var hash = md5.ComputeHash(inputBytes);
            return Md5ReplaceRegex.Replace(BitConverter.ToString(hash), Empty).ToLower().Substring(8, 16);
        }
    }
}