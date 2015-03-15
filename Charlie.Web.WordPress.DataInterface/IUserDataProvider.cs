using System.Threading.Tasks;

namespace Charlie.Web.WordPress.Data
{
    public interface IUserDataProvider
    {
        Task<Models.User> Register(Models.User newUser);

        Task<Models.User> Login(Models.User user);

        Task<Models.User> Lock(Models.User user);

        
    }

    public interface ILoginUserDataProvider
    {
        Task<Models.User> ChangePassword(Models.User user, string oldPassword, string newPassword);


    }


 
}