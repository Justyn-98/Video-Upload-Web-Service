using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ApiModels
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required, MaxLength(256)]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
