using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItBolt.Model.Entities
{
    //[Keyless]
    public class Felhasznalo
    {
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [StringLength(15)]
        public string nev { get; set; } = null!;
        [StringLength(15)]
        public string jelszo { get; set; } = null!;
    }
}
