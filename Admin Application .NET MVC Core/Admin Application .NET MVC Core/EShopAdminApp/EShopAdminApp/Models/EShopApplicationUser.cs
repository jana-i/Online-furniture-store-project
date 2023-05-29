using Microsoft.AspNetCore.Identity;

namespace EShopAdminApp.Models
{
    public class EShopApplicationUser 
    {

        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
    }
}
