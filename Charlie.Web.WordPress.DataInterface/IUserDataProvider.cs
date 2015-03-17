using System.Threading.Tasks;
using Charlie.Web.WordPress.Models.Passport;
using System;
using Microsoft.AspNet.Identity;

namespace Charlie.Web.WordPress.Data
{
    public interface IUserDataProvider
    {
        Task<Models.User> Register(Models.User newUser);

        Task<Models.User> Login(Models.User user);

        Task<Models.User> Lock(Models.User user);

        
    }

    public interface IUserRegisterProvider:IDisposable
    {
        Task<Models.User> Register(RegisterViewModel user);
        IPasswordHasher PasswordHasher { get; }
        IUserDataValidationProvider Validation { get; }

    }


    public interface ILoginUserDataProvider
    {
        Task<Models.User> ChangePassword(Models.User user, string oldPassword, string newPassword);


    }


 
}