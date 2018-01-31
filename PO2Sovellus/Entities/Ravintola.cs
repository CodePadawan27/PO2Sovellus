using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PO2Sovellus.Entities
{
    public class Ravintola
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nimi on pakollinen"), MaxLength(200)]
        [Display(Name = "Ravintolan nimi")]
        public string Nimi { get; set; }
    }
}
