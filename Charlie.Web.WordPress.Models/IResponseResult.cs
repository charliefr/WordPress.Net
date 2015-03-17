using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Web.WordPress.Models
{

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ResponseResult : IResponseResult
    {
        /// <summary>
        /// The succeed response result
        /// </summary>
        private static readonly ResponseResult SucceedResponseResult = new ResponseResult(true);
        /// <summary>
        /// The _succeed
        /// </summary>
        private readonly bool _succeed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult"/> class.
        /// </summary>
        /// <param name="succeed">if set to <c>true</c> [succeed].</param>
        protected ResponseResult(bool succeed)
        {
            this._succeed = succeed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <exception cref="System.ArgumentNullException">errors</exception>
        protected ResponseResult(params string[] errors)
            : this(false)
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors");
            }
            this.Errors = errors.ToArray();
        }


        /// <summary>
        /// Gets a value indicating whether this <see cref="IResponseResult" /> is succeeded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if succeeded; otherwise, <c>false</c>.
        /// </value>
        public bool Succeeded
        {
            get { return _succeed; }
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<string> Errors { get; protected set; }

        /// <summary>
        /// Gets the success.
        /// </summary>
        /// <value>
        /// The success.
        /// </value>
        public static ResponseResult Success
        {
            get { return SucceedResponseResult; }
        }
        /// <summary>
        /// Faileds the specified errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public static ResponseResult Failed(params string[] errors)
        {
            return new ResponseResult(errors);
        }
    }

}

namespace Charlie.Web.WordPress
{

    /// <summary>
    /// 
    /// </summary>
    public interface IResponseResult
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IResponseResult"/> is succeeded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if succeeded; otherwise, <c>false</c>.
        /// </value>
        bool Succeeded { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        IEnumerable<string> Errors
        {
            get;

        }

    }

}