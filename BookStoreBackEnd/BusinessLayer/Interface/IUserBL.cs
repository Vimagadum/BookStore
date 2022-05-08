using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistrationModel UserRegister(UserRegistrationModel userRegistration);
        public string UserLogin(string email, string password);

    }
}
