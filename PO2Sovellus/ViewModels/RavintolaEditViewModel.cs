using Sovellus.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PO2Sovellus.ViewModels
{
    public class RavintolaEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nimi on pakollinen"), MaxLength(200)]
        [Display(Name = "Ravintolan nimi")]
        public string Nimi { get; set; }
        [Required(ErrorMessage = "Kaupunki on pakollinen")]
        [Display(Name = "Kaupunki")]
        public int KaupunkiId { get; set; }
        [Display(Name = "Ravintolatyyppi")]
        public int? TyyppiId { get; set; }
        public string Katuosoite { get; set; }
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Postinumero on oltava tasan 5 merkkiä.")]
        [Display(Name = "Postinumero")]
        public string Postinro { get; set; }
        [Display(Name = "Kuvan url‐osoite")]
        public string KuvaUrl { get; set; }
        [Display(Name = "Kotisivu")]
        public string KotisivuUrl { get; set; }
        public List<Kaupunki> Kaupungit { get; set; }
        public List<RavintolaTyyppi> RavintolaTyypit { get; set; }
    }
}