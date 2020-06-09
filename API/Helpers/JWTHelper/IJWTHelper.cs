using API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.JWTHelper
{
    public interface IJWTHelper
    {
        public string GenerateJSONWebToken(User user);
    }
}
