using Microsoft.AspNetCore.Http;
using NetCore.Data.Context;
using NetCore.Data.Entities;
using NetCore.Data.Models;
using System;
using System.Threading.Tasks;

namespace NetCore.Data.Repositories;

public class UnitOfWork : IDisposable
{
    private readonly NetCoreDbContext context;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UnitOfWork(NetCoreDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> Save()
    {
        int? userId = null;
        var httpContextUserId = httpContextAccessor.HttpContext?.Items["userId"];
        if (httpContextUserId != null)
            userId = (int?)httpContextUserId;
        var auditLogCreateDto = new AuditLogCreateDto
        {
            Method = httpContextAccessor.HttpContext?.Request.Method ?? string.Empty,
            UserId = userId
        };
        return await context.SaveChangesAsync(auditLogCreateDto) > 0;
    }

    private BaseRepository<User> userRepository;
    public BaseRepository<User> UserRepository
    {
        get
        {
            userRepository ??= new BaseRepository<User>(context, httpContextAccessor);
            //if (userRepository == null)
            //    userRepository = new BaseRepository<User>(context, httpContextAccessor);
            return userRepository;
        }
    }

    private BaseRepository<Product> productRepository;
    public BaseRepository<Product> ProductRepository
    {
        get
        {
            productRepository ??= new BaseRepository<Product>(context, httpContextAccessor);
            return productRepository;
        }
    }

    private BaseRepository<Category> categoryRepository;
    public BaseRepository<Category> CategoryRepository
    {
        get
        {
            categoryRepository ??= new BaseRepository<Category>(context, httpContextAccessor);
            return categoryRepository;
        }
    }

    private BaseRepository<ProductInCategory> productInCategoryRepository;
    public BaseRepository<ProductInCategory> ProductInCategoryRepository
    {
        get
        {
            productInCategoryRepository ??= new BaseRepository<ProductInCategory>(context, httpContextAccessor);
            return productInCategoryRepository;
        }
    }

    // Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}