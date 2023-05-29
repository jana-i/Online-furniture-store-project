using EShop.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace EShop.Domain.Identity
{
    public class EShopApplicationUser : IdentityUser
    {
        public readonly bool Succeeded;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }

        public static implicit operator EShopApplicationUser(IdentityResult v)
        {
            throw new NotImplementedException();
        }
    }
}
