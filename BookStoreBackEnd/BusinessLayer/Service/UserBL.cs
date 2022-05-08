using BusinessLayer.Interface;
using CommonLayer.Model;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;


        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public string ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            try
            {
                return this.userRL.ForgotPassword(forgotPasswordModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                return this.userRL.ResetPassword(email,newPassword,confirmPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UserLogin(string email, string password)
        {
            try
            {
                return this.userRL.UserLogin(email, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserRegistrationModel UserRegister(UserRegistrationModel userRegistration)
        {
            try
            {
                return this.userRL.UserRegister(userRegistration);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
