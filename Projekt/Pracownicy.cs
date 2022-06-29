using System.ComponentModel.DataAnnotations;

namespace Projekt
{
    public class Pracownicy
    {
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public int AdresyId { get; set; }
        public virtual Adresy Adres { get; set; }

        public int StanowiskaId { get; set; }
        public virtual Stanowiska Stanowisko { get; set; }

        public int PlacowkiId { get; set; }
        public virtual Placowki Placowka { get; set; }



    }
}