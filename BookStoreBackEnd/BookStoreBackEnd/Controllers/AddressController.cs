using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [HttpPost("Add")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var address = this.addressBL.AddAddress(addressModel, userId);
                if (address.Equals("Address Added Successfully"))
                {
                    return this.Ok(new { Status = true, Message = "Address added successfully", Response = address });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Response = address });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPut("Update/{addressId}")]
        public IActionResult UpdateAddress(AddressModel addressModel, int addressId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var address = this.addressBL.UpdateAddress(addressModel, addressId, userId);
                if (address != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully Address Updated", Response = address });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "failed to update address" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete("Delete/{address_Id}")]
        public IActionResult DeleteAddress(int address_Id)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.addressBL.DeleteAddress(address_Id, userId))
                {
                    return this.Ok(new { Status = true, Message = "Address Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "failed to delete address" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get")]
        public IActionResult GetAllAddresses()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var addresses = this.addressBL.GetAllAddresses(userId);
                if (addresses != null)
                {
                    return this.Ok(new { Status = true, Message = " Successfully All Address Fetched and Displayed", Response = addresses });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "failed to fetcch address" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
