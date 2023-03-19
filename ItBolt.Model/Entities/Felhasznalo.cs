using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItBolt.Model.Entities
{
   
    public partial class Felhasznalo
    {
        public Felhasznalo()
        {

        }
        public Felhasznalo(string? nev, string? jelszo)
        {
            this.nev = nev;
            this.jelszo = jelszo;
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [StringLength(15)]
        public string? nev { get; set; }
        [StringLength(15)]
        public string? jelszo { get; set; }
    }
}
