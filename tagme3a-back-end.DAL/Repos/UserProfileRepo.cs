using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly MainDbContext _context;


        public UserProfileRepo(UserManager<User> userManager , MainDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        async  Task<User> IUserProfileRepo.GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        async Task IUserProfileRepo.UpdateUser(User user , string userId)
        {
            User existingUser = await _userManager.FindByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User not found"); 
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email; 
            existingUser.Addresses = user.Addresses;
            existingUser.Fname = user.Fname;
            existingUser.Lname = user.Lname;
            existingUser.Gender = user.Gender;
            existingUser.PhoneNumber = user.PhoneNumber;

            await _userManager.UpdateAsync(existingUser);
            await _context.SaveChangesAsync();

        }
    }
}
