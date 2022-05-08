using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ResositoryLayer.Service
{
    public class UserRL : IUserRL 
    {
        private SqlConnection sqlConnection;
        private IConfiguration Configuration { get; }

        public UserRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public UserRegistrationModel UserRegister(UserRegistrationModel userRegistration)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spRegisterUser", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", userRegistration.Fullname);
                    cmd.Parameters.AddWithValue("@Email", userRegistration.Email);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@MobileNumber", userRegistration.Mobile);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return userRegistration;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
