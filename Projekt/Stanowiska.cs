using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt
{
    public class Stanowiska
    {
        [Key]
        public int StanowiskaId { get; set; }
        public string Stanowisko { get; set; }
        public Pracownicy Pracownicy { get; set; }
    }
}