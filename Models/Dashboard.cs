using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Dashboard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string Mail { get; set; }

        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon adresi değil")]
        public string Phone { get; set; }
    
    }
}
