using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charlie.Web.WordPress.Data.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace Charlie.Web.WordPress.Data.Sql
{
    public class SqlUserRegisterProvider : IUserRegisterProvider
    {
        private readonly DataContext _context;
        private readonly SqlUserDataValidationProvider _validation;
        private readonly Microsoft.AspNet.Identity.PasswordHasher _passwordHasher;

        public SqlUserRegisterProvider(DataContext context)
        {
           
            this._context = context;
            this._validation = new SqlUserDataValidationProvider(context);
            this._passwordHasher = new PasswordHasher();
        }
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ValidationException"></exception>
        public virtual async Task<User> Register(WordPress.Models.Passport.RegisterViewModel user)
        {
            if (user==null)
            {
                throw new ArgumentNullException("user");
            }
            var emailAvailable = await this.Validation.IsAvailableEmail(user.Email);
            if (!emailAvailable.Succeeded)
            {
                throw new ValidationException(user.Email + "  is uvailable email");
            }
            var nameAvailable = await this.Validation.IsAvailableUserName(user.UserName);
            if (!nameAvailable.Succeeded)
            {
                throw new ValidationException(user.UserName + "  is uvailable name");
            }
            var model = new User()
            {
                DisplayName = user.UserName,
                IsMailVerified = false,
                Name = user.UserName,
                Mailbox = user.Email,
                Password = this.PasswordHasher.HashPassword(user.Password),
                RegisteredTime = DateTime.Now,
                Status = 0
            };
            _context.Users.Add(model);
            return await _context.SaveChangesAsync().ContinueWith(args =>
            {
                if (args.IsFaulted)
                {
                    throw args.Exception;
                }

                return model;

            });
        }

        public virtual IUserDataValidationProvider Validation
        {
            get
            {
                return _validation;
            }
        }




        public void Dispose()
        {
            _context.Dispose();
        }


        public virtual IPasswordHasher PasswordHasher
        {
            get { return _passwordHasher; }
        }
    }
}
