using Catalog.Dtos;
using Catalog.Entities;
using Object = Catalog.Entities.Object;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserId = user.UserId,
                UserName = user.UserName,
                Language = user.Language,
                Email = user.Email,
                UserRole = user.UserRole,
                ManagerRole = user.ManagerRole,
                AuthorizationAmount = user.AuthorizationAmount
            };

        }
        public static CompanyDto AsDto(this Company company)
        {
            return new CompanyDto
            {
                Id = company.Id,
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyBaseCurrency = company.CompanyBaseCurrency,
                TaxRegistrationNumber = company.TaxRegistrationNumber,
                ContactPerson = company.ContactPerson,
                ContactPersonEmail = company.ContactPersonEmail,
                ErrorHandlingRole = company.ErrorHandlingRole,
                PreliminaryRecordingInERP = company.PreliminaryRecordingInERP
            };


        }

        public static ObjectDto AsDto(this Object vobject)
        {
            return new ObjectDto
            {
                Id = vobject.Id,
                ObjectTypeNo = vobject.ObjectTypeNo,
                ObjectId = vobject.ObjectId,
                Name = vobject.Name
            };
        }
    }
}
