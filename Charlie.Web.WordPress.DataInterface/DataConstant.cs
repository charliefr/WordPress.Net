using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Web.WordPress.Data
{
    internal abstract class DataConstant
   {
       public const int UserNameMaxLength = 16;
       public const int UserNameMinLength = 1;
       public const string UserNameStringLengthErrorMessage = "UserNameStringLengthErrorMessage";
       public const string UserEmailUnavailableErrorMessage = "UserEmailUnavailableErrorMessage";
   }
}
