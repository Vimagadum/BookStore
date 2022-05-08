using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegistrationModel UserRegister(UserRegistrationModel userRegistration);
        public string UserLogin(string email, string password);

    }
}
