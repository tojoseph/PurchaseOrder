using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Core.Models;
using PurchaseOrder.Services.Interfaces;

namespace PurchaseOrder.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductDetailsModel productDetails)
        {
            if (productDetails != null)
            {
                // check exist product
                var _product = await this._unitOfWork.Products.GetById(Convert.ToInt32(productDetails.Id));
                if (_product == null)
                {
                    _product = this.mapper.Map<ProductDetailsModel, TblProductDetails>(productDetails);
                    _product.UpdatedBy = 1;
                    _product.UpdatedOn = DateTime.Now;
                    _product.CreatedOn = DateTime.Now;
                    _product.CreatedBy = 1;

                    await _unitOfWork.Products.Add(_product);
                }

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.Products.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetailsModel>> GetAllProducts()
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            var result =  this.mapper.Map<IEnumerable<TblProductDetails>, IEnumerable<ProductDetailsModel>>(productDetailsList);
            return result;
        }

        public async Task<ProductDetailsModel> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    return this.mapper.Map<TblProductDetails, ProductDetailsModel>(productDetails);
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(ProductDetailsModel productDetails)
        {
            if (productDetails != null)
            {
                var product = await _unitOfWork.Products.GetById(Convert.ToInt32(productDetails.Id));
                if (product != null)
                {
                    product = mapper.Map<ProductDetailsModel, TblProductDetails>(productDetails, product);
                    product.UpdatedBy = 1;
                    product.UpdatedOn = DateTime.Now;
                    
                    _unitOfWork.Products.Update(product);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
