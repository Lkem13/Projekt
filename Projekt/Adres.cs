using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string NumerMieszkania { get; set; }
        public string KodPocztowy { get; set; }

    }
}
