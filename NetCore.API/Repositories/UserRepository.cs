using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Data.Data;
using NetCore.Data.Models;

namespace NetCore.API.Repositories
{
    public interface IUserRepository
    {
        public Task<User> Detail(long ID);
        public Task<User> GetUser(string username);
        public Task<bool> CreateUser(User user);
        public Task<bool> UpdateUser(User user);
    }

    public class UserRepository: IUserRepository
    {
        private readonly NetCoreDbContext _context;

        public UserRepository(NetCoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> Detail(long ID)
        {
            return await _context.Users.SingleOrDefaultAsync(item => item.ID == ID);
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(item => item.Username == username);
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(user.ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProductExists(long id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
