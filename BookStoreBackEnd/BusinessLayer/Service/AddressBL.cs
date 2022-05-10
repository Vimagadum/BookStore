using BusinessLayer.Interface;
using CommonLayer.Model;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public string AddAddress(AddressModel addressModel, int user_Id)
        {
            try
            {
                return addressRL.AddAddress(addressModel, user_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAddress(int address_Id, int user_Id)
        {
            try
            {
                return addressRL.DeleteAddress(address_Id, user_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressModel> GetAllAddresses(int user_Id)
        {
            try
            {
                return addressRL.GetAllAddresses(user_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressModel UpdateAddress(AddressModel addressModel, int address_Id, int user_Id)
        {
            try
            {
                return addressRL.UpdateAddress(addressModel, address_Id, user_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
