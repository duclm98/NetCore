using AutoMapper;
using AutoWrapper.Wrappers;
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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.API.Services
{
    public interface IProductService
    {
        Task<ApiResponse> GetAll();
        Task<ApiResponse> GetSingle(int productId);
        Task<ApiResponse> Add(ProductCreateDto productCreateDto);
        Task<ApiResponse> Update(int productId, ProductUpdateDto productUpdateDto);
        Task<ApiResponse> Delete(int productId);
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

        public async Task<ApiResponse> GetAll()
        {
            var productQueryable = _unitOfWork.ProductRepository.Queryable;
            var products = await productQueryable.ToListAsync();
            var productDtos = GetInfo(products);

            //
            MonitorLoop monitorLoop = _host.Services.GetRequiredService<MonitorLoop>()!;
            await monitorLoop.MonitorAsync(new Service(new GetProductWorkerService()));

            return new ApiResponse("Thành công", productDtos);
        }

        public async Task<ApiResponse> GetSingle(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException(404, "Sản phẩm không tồn tại");
            var productDto = GetInfo(product);
            return new ApiResponse("Thành công", productDto);
        }

        public async Task<ApiResponse> Add(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price
            };
            await _unitOfWork.ProductRepository.Insert(product);
            if (!await _unitOfWork.Save())
                throw new CustomException(500, "Tạo sản phẩm không thành công");

            var productDto = GetInfo(product);
            return new ApiResponse("Tạo sản phẩm thành công", productDto);
        }

        public async Task<ApiResponse> Update(int productId, ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException(404, "Sản phẩm không tồn tại");

            product.Name = productUpdateDto.Name ?? product.Name;
            product.Price = productUpdateDto.Price != 0 ? productUpdateDto.Price : product.Price;

            _unitOfWork.ProductRepository.Update(product);
            if (!await _unitOfWork.Save())
                throw new CustomException(500, "Cập nhật sản phẩm không thành công");

            var productDto = GetInfo(product);
            return new ApiResponse("Cập nhật sản phẩm thành công", productDto);
        }

        public async Task<ApiResponse> Delete(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId);
            if (product == null)
                throw new CustomException(404, "Sản phẩm không tồn tại");
            _unitOfWork.ProductRepository.Delete(product);
            if (!await _unitOfWork.Save())
                throw new CustomException(500, "Xóa sản phẩm không thành công");

            var productDto = GetInfo(product);
            return new ApiResponse("Xóa sản phẩm thành công", productDto);
        }

        // ============================= PRIVATE SERVICE ================================
        private List<ProductDto> GetInfo(List<Product> products) =>
            _mapper.Map<List<ProductDto>>(products);

        private ProductDto GetInfo(Product product) =>
            _mapper.Map<ProductDto>(product);
    }
}