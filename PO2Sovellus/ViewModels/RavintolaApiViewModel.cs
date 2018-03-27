using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewModels
{
    public class RavintolaApiViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nimi on pakollinen"),
        MaxLength(200, ErrorMessage = "Nimi voi olla korkeintaan 200 merkkiä pitkä.")]
        public string Nimi { get; set; }
        [Required(ErrorMessage = "Kaupunki on pakollinen")]
        public int KaupunkiId { get; set; }
        public int? TyyppiId { get; set; }
        public string Katuosoite { get; set; }
        [StringLength(5, MinimumLength = 5,
        ErrorMessage = "Postinumero on oltava tasan 5 merkkiä.")]
        public string Postinro { get; set; }
        public string KuvaUrl { get; set; }
        public string KotisivuUrl { get; set; }
    }
}
