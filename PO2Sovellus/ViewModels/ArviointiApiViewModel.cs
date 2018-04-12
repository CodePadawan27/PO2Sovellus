using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewModels
{
    public class ArviointiApiViewModel
    {
        public int Id { get; set; }
        public int RavintolaId { get; set; }
        [Required(ErrorMessage = "Arvio on pakollinen."),
        Range(1, 5, ErrorMessage = "Arvion on oltava kokonaisluku väliltä 1-5.")]

        public short Arvio { get; set; }
        [Required(ErrorMessage = "Sanallinen arviointi on pakollinen."),
        StringLength(1000, ErrorMessage = "Sanallinen arviointi saa olla korkeintaan 1000 merkkiä pitkä.")]


public string Teksti { get; set; }
        public short? HintaLaatu { get; set; }
        public short? Palvelu { get; set; }
        public short? Ymparisto { get; set; }
        public DateTime Aika { get; set; }
    }
}
