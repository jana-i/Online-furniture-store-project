using EShop.Domain;
using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<EShopApplicationUser> _userManager;

        public AdminController(IOrderService orderService, UserManager<EShopApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = this._orderService.getAllOrders();
            return result;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            var result = this._orderService.getOrderDetails(model);
            return result;
        }



        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new EShopApplicationUser
                    {
                        FirstName = item.Name,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = item.PhoneNumber,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;

                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
