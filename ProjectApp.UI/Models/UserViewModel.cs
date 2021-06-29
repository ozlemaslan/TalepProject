using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApp.UI.Models
{
    public class UserViewModel
    {
       
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        //[MinLength(8, ErrorMessage = "Şifre en fazla 8 karakter uzunluğunda olmalıdır.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        //public string ConfirmPassword { get; set; }

        [MinLength(11, ErrorMessage = "Telefon numarası en fazla 11 karakter uzunluğunda olmalıdır.")]
        public string Phone { get; set; }
    }
}
