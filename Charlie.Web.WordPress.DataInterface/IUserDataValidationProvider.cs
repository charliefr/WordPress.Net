using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using Charlie.Web.WordPress.Models;

namespace Charlie.Web.WordPress.Data
{
    public interface IUserDataValidationProvider : IDisposable
    {
        [DebuggerStepThrough]
        Task<IResponseResult> IsAvailableUserName(
            [Required,StringLength(DataConstant.UserNameMaxLength, 
                MinimumLength = DataConstant.UserNameMinLength, 
                ErrorMessageResourceName = DataConstant.UserNameStringLengthErrorMessage)]
                string name);
        [DebuggerStepThrough]
        Task<IResponseResult> IsAvailableEmail([Required, EmailAddress(ErrorMessageResourceName = DataConstant.UserEmailUnavailableErrorMessage)]string email);
    }

    public interface IUserPasswordSafetyTestProvider
    {
        [DebuggerStepThrough]
        Task<IResponseResult> IsAvailablePassword([Required] string password);
    }
}