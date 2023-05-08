using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers.ProfileManager
{
    public interface IUserProfileManager
    {
        Task<User> getUserbyId (string UserId);

        Task UpdateUser(User user , string UserId);
    }
}
