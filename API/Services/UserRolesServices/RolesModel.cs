using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.UserRolesServices
{
    public class RolesModel
    {
        public static string Admin { get; private set; } = "Administrator";

        public static string CustomUser { get; private set; } = "CustomUser";
    }
}
