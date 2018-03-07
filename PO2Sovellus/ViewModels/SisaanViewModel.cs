using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewModels
{
    public class SisaanViewModel
    {
        [Display(Name = "Käyttäjätunnus")]
        [Required(ErrorMessage = "Käyttäjätunnus on pakollinen")]
        public string UserName { get; set; }
        [Display(Name = "Salasana")]
        [Required(ErrorMessage = "Salasana on pakollinen"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Muista minut")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
