using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepositoty
    {
        private readonly PageContext _pageContext;

        public UserRepository(PageContext pageContext)
        {
            _pageContext = pageContext;
        }
        
        
        public async Task<Users> CreateUserAsync(Users users)
        {
            await _pageContext.AddAsync(users);
             await _pageContext.SaveChangesAsync();
            return users;
        }


        public async Task<Users> DeleteUserAsync(int Id)
        {
            var user = await _pageContext.Users.FirstOrDefaultAsync(i=>i.Id == Id);
             _pageContext.Remove(user);
            await _pageContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            {
                try
                {
                    var user = await _pageContext.Users.ToListAsync();
                    return user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }


        public async Task<Users> GetUserAsync(int Id)
        {
            var user = await _pageContext.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<Users> UpdateUserAsync(int Id, Users user)
        {
            var userExist = await _pageContext.Users.FirstOrDefaultAsync(x =>x.Id == Id);
            if (userExist == null)
            {
                return null;
            }
            userExist.UpdatedDate = user.UpdatedDate;
            userExist.CreatedDate = user.CreatedDate;
            userExist.UpdatedBy = user.UpdatedBy;
            userExist.CreatedBy = user.CreatedBy;

            userExist.Email = user.Email;
            userExist.Username = user.Username;
            userExist.Password = user.Password;
            userExist.Roles = user.Roles;

            return user;

        }


    }
}
