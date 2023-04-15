using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.User
{
    public record UserRegisterDto
    (
        string UserName,
        string Fname,
        string Lname,
        Gender Gender,
        string Email,
        string Password
    );
}
