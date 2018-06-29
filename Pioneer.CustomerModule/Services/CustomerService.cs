using Pioneer.CustomerModule.Exceptions;
using Pioneer.CustomerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.CustomerModule.Services
{
    public class CustomerService : ICustomerService
    {
        public IQueryable<CustomerResponse> Get()
        {
            //return _context.Buyers.Where(x => x.DeleteStatus == EntityStatus.Active)
            //    .Select(x => new BuyerResponse
            //    {
            //        CreatedBy = _context.Users.Where(a => a.ID == x.CreatedBy).Select(b => b.FirstName + " " + b.LastName).FirstOrDefault(),
            //        OrganizationId = x.UserMaster.OrganizationMasterId,
            //        CreatedOn = x.CreatedOn,
            //        Id = x.ID,
            //        State = x.State,
            //        UpdatedBy = _context.Users.Where(a => a.ID == x.UpdatedBy).Select(b => b.FirstName + " " + b.LastName).FirstOrDefault(),
            //        UpdatedOn = x.UpdatedOn,
            //        BrandName = x.BrandName,
            //        BuyerAddress = x.BuyerAddress,
            //        BuyerContactNumber = x.BuyerContactNumber,
            //        BuyerEmail = x.BuyerEmail,
            //        BuyerName = x.BuyerName,
            //        BuyerPincode = x.BuyerPincode,
            //        BuyerPocContactNumber = x.BuyerPocContactNumber,
            //        BuyerPocName = x.BuyerPocName,
            //        BuyerType = x.BuyerType,
            //        CompanyRegistrationNo = x.CompanyRegistrationNo,
            //        FcaNo = x.FcaNo,
            //        IcoExpDate = x.IcoExpDate,
            //        IcoNo = x.IcoNo,
            //        IsSendNotifyMail = x.IsSendNotifyMail,
            //        IsSubscribe = x.IsSubscribe

            //    });
            return null;
        }

        public CustomerResponse GetById(int id)
        {
            //  var buyer = _context.Buyers.FirstOrDefault(x => x.ID == id && x.DeleteStatus == EntityStatus.Active);
            //  if (buyer == null)
            //   {
            throw new CustomerNotFoundException();
            //  }
            //  return _buyerMapper.MapToBuyerResponse(buyer);
        }
        public CustomerResponse GetByUserName(string userName)
        {
            //var buyer = _context.Buyers.FirstOrDefault(x => x.BuyerEmail.Equals(userName, StringComparison.InvariantCultureIgnoreCase));// username here email
            //if (buyer == null)
            //{
            throw new CustomerNotFoundException();
            //}
            //  return _buyerMapper.MapToBuyerResponse(buyer);
        }
        public int Create(CustomerCreate buyer)
        {
            //var buyerEntity = Mapper.Map<CreateBuyerRequest, BuyerMaster>(buyer);
            //buyerEntity = _saveBuyer.Save<BuyerMaster>(buyerEntity, 0);
            // return buyerEntity.ID;
            return 1;
        }
        public void Update(CustomerCreate buyer)
        {
            //var buyerEntity = Mapper.Map<CustomerCreate, BuyerMaster>(buyer);
            //_saveBuyer.Save<BuyerMaster>(buyerEntity, buyerEntity.ID);
        }
        public void Delete(int id)
        {
            //var buyerEntity = _context.Buyers.FirstOrDefault(x => x.ID == id && x.DeleteStatus == EntityStatus.Active);
            //if (buyerEntity == null)
            //{
            //    throw new CustomerNotFoundException();
            //}
            //buyerEntity.DeleteStatus = EntityStatus.Deleted;
            //_saveBuyer.Save<BuyerMaster>(buyerEntity, buyerEntity.ID);
        }
    }
}
