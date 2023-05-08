using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.Managers.ProfileManager;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.UserProfileManager
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly IUserProfileRepo _userProfileRepo;

        public UserProfileManager(IUserProfileRepo userProfileRepo)
        {
            _userProfileRepo = userProfileRepo;
        }
        public async Task<User> getUserbyId(string UserId)
        {
            return await _userProfileRepo.GetUserById(UserId);
        }

        public async Task UpdateUser(User user, string userId)
        {
            await _userProfileRepo.UpdateUser(user, userId);
        }

    }
}
