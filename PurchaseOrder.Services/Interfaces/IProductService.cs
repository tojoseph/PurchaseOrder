using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductDetailsModel productDetails);

        Task<IEnumerable<ProductDetailsModel>> GetAllProducts();

        Task<ProductDetailsModel> GetProductById(int productId);

        Task<bool> UpdateProduct(ProductDetailsModel productDetails);

        Task<bool> DeleteProduct(int productId);
    }
}
