using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    public partial class Kategoria
    {
        public Kategoria()
        {
            eszkoz = new HashSet<Eszkoz>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int kategoriaID { get; set; }
        [StringLength(50)]
        public string? kategoria_nev { get; set; }

        [JsonIgnore]
        [InverseProperty("kategoria")]
        public virtual ICollection<Eszkoz> eszkoz { get; set; }
    }
}
