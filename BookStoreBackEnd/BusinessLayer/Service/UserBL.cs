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
