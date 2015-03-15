using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Web.WordPress.Models
{

    [Serializable]
    public class ResponseResult:IResponseResult
    {
        private static readonly ResponseResult SucceedResponseResult = new ResponseResult(true);
        private readonly  bool _succeed;

        protected ResponseResult(bool succeed)
        {
            this._succeed = succeed;
        }

        protected ResponseResult(params string[] errors)
            : this(false)
        {
            if (errors==null)
            {
                throw new ArgumentNullException("errors");
            }
            this.Errors = errors.ToArray();
        }


        public bool Succeeded
        {
            get { return _succeed; }
        }

        public IEnumerable<string> Errors { get; protected set; }

        public static ResponseResult Success
        {
            get { return SucceedResponseResult; }
        }
        public static ResponseResult Failed(params string[] errors)
        {
            return new ResponseResult(errors);
        }
    }
    
}

namespace Charlie.Web.WordPress
{

    public interface IResponseResult
    {
        bool Succeeded { get; }
       
         IEnumerable<string>Errors 
        {
            get;

        }

    }

}