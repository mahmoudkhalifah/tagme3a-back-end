using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.User
{
    public record UserTokenReturnDto(string Token, DateTime Expiry);
}
