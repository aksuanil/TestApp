using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class LoginAccounts
    {
        //RegEx ile istenilen şifre kısıtlamalrının sağlanması//

        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Lütfen bir mail adresi girin")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Parolanız parola doğrulamayla eşleşmiyor!")]
        [StringLength(8, ErrorMessage = "Parolanız en fazla 8 karakter olabilir")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d))(?=.*[^\da-zA-Z]).+$", ErrorMessage = "Parolanız koşullara uymuyor!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı doğrulayın")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [StringLength(8, ErrorMessage = "Parolanız en fazla 8 karakter olabilir")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d))(?=.*[^\da-zA-Z]).+$", ErrorMessage = "Parolanız koşullara uymuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
