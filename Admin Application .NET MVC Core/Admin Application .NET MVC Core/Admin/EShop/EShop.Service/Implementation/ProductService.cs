using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Domain.Relations;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
        }


        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.SelectedProductId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForProduct(item.SelectedProductId);
                //{896c1325-a1bb-4595-92d8-08da077402fc}

                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CurrnetProduct = product,
                        ProductId = product.Id,
                        UserCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.ProductInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.ProductId == itemToAdd.ProductId).FirstOrDefault();

                    if(existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._productInShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._productInShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedProduct = product,
                SelectedProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
