using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.API.Dto.Product;
using NetCore.API.QueueService;
using NetCore.API.QueueService.WorkerService;
using NetCore.API.QueueService.WorkerService.ProductWorkerService;
using NetCore.Data.Entities;
using NetCore.Data.Repositories;
using NetCore.Helpers.Exceptions;
using NetCore.Helpers.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.API.Services
{
    public interface IProductService
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetSingle(int productId);
        Task<IActionResult> Add(ProductCreateDto productCreateDto);
        Task<IActionResult> Update(int productId, ProductUpdateDto productUpdateDto);
        Task<IActionResult> Delete(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly IHost _host;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, UnitOfWork unitOfWork, IHost host)
        {
            _host = host;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> GetAll()
        {
            var productQueryable = _unitOfWork.ProductRepository.Queryable;
            var products = await productQueryable.ToListAsync();
            var productDtos = GetInfo(products);

            //
            MonitorLoop monitorLoop = _host.Services.GetRequiredService<MonitorLoop>()!;
            await monitorLoop.MonitorAsync(new Service(new GetProductWorkerService()));

            return new CustomResult("Thành công", productDtos);
        }

        public async Task<IActionResult> GetSingle(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException("Sản phẩm không tồn tại", 404);
            var productDto = GetInfo(product);
            return new CustomResult("Thành công", productDto);
        }

        public async Task<IActionResult> Add(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price
            };
            await _unitOfWork.ProductRepository.Insert(product);
            if (!await _unitOfWork.Save())
                throw new CustomException("Tạo sản phẩm không thành công", 500);

            var productDto = GetInfo(product);
            return new CustomResult("Tạo sản phẩm thành công", productDto, 201);
        }

        public async Task<IActionResult> Update(int productId, ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException("Sản phẩm không tồn tại", 404);

            product.Name = productUpdateDto.Name ?? product.Name;
            product.Price = productUpdateDto.Price != 0 ? productUpdateDto.Price : product.Price;

            _unitOfWork.ProductRepository.Update(product);
            if (!await _unitOfWork.Save())
                throw new CustomException("Cập nhật sản phẩm không thành công", 500);

            var productDto = GetInfo(product);
            return new CustomResult("Cập nhật sản phẩm thành công", productDto);
        }

        public async Task<IActionResult> Delete(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException("Sản phẩm không tồn tại", 404);
            _unitOfWork.ProductRepository.Delete(product);
            if (!await _unitOfWork.Save())
                throw new CustomException("Xóa sản phẩm không thành công", 500);

            var productDto = GetInfo(product);
            return new CustomResult("Xóa sản phẩm thành công", productDto);
        }

        // ============================= PRIVATE SERVICE ================================
        private List<ProductDto> GetInfo(List<Product> products) =>
            _mapper.Map<List<ProductDto>>(products);

        private ProductDto GetInfo(Product product) =>
            _mapper.Map<ProductDto>(product);
    }
}