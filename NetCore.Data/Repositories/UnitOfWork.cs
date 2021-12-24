using NetCore.Data.Context;
using NetCore.Data.Entities;
using System.Threading.Tasks;

namespace NetCore.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly NetCoreDbContext context;

        public UnitOfWork(NetCoreDbContext context)
        {
            this.context = context;
        }

        private BaseRepository<User> userRepository;
        public BaseRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new BaseRepository<User>(context);
                return userRepository;
            }
        }

        private BaseRepository<Product> productRepository;
        public BaseRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new BaseRepository<Product>(context);
                return productRepository;
            }
        }

        public async Task<bool> Save()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}