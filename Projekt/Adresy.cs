using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Adresy
    {
      
        public int AdresyId { get; set; }
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string Mieszkanie { get; set; }

        public Pracownicy Pracownicy { get; set; }
    }
}
