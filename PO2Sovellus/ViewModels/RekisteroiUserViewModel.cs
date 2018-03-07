using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewModels
{
    public class RekisteroiUserViewModel
    {
        [Display(Name = "Käyttäjätunnus")]
        [Required(ErrorMessage = "Käyttäjätunnus on pakollinen"), MaxLength(256)]
        public string UserName { get; set; }
        [Display(Name = "Salasana")]
        [Required(ErrorMessage = "Salasana on pakollinen"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Salasanan vahvistus")]
        [DataType(DataType.Password), Compare(nameof(Password),
            ErrorMessage = "Salasanan vahvistus ei ole sama kuin salasana.")]
        public string ConfirmPassword { get; set; }
    }
}
