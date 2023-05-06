using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private readonly UserManager<User> _userManager;

        public UserProfileRepo(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        async  Task<User> IUserProfileRepo.GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        async Task IUserProfileRepo.UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }
    }
}
