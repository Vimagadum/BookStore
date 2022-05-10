using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResositoryLayer.Interface
{
    public interface IAddressRL
    {
        public string AddAddress(AddressModel addressModel, int user_Id);
    }
}
