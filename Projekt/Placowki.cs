using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt
{
    public class Placowki
    {
        [Key]
        public int PlacowkiId { get; set; }
        public string Placowka { get; set; }
        public Pracownicy Pracownicy { get; set; }
    }
}