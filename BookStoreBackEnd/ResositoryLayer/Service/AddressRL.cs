﻿using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ResositoryLayer.Service
{
    public class AddressRL : IAddressRL 
    {
        private SqlConnection sqlConnection;
        private IConfiguration Configuration { get; }
        public AddressRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string AddAddress(AddressModel addressModel, int user_Id)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddAddress", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    cmd.Parameters.AddWithValue("@UserId", user_Id);
                    sqlConnection.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlConnection.Close();
                    if (i == 2)
                    {
                        return "Please Enter Correct Address TypeId For Adding Address";
                    }
                    else
                    {
                        return "Address Added Successfully";
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
