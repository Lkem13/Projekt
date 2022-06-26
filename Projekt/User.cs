using System.ComponentModel.DataAnnotations;

namespace Projekt
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

    }
}