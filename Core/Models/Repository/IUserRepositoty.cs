using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
    public interface IUserRepositoty
    {
        public Task<List<Users>> GetAllAsync();
        public Task<Users> GetUserAsync(int Id);
        public Task<Users> UpdateUserAsync(int Id, Users user);
        public Task<Users> CreateUserAsync(Users user);
        public Task<Users> DeleteUserAsync(int Id);

    }
}
