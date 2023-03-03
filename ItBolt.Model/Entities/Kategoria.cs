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
        [StringLength(25)]
        public string kategoriaID { get; set; } = null!;
        [StringLength(50)]
        public string? kategoria_nev { get; set; }

        [JsonIgnore]
        [InverseProperty("kategoria")]
        public virtual ICollection<Eszkoz> eszkoz { get; set; }
    }
}
