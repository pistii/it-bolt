using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    public partial class Raktar
    {
        public Raktar()
        {
            raktarak = new HashSet<Bolt>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int raktarID { get; set; }
        [StringLength(50)]
        public string raktar_neve { get; set; }
        [StringLength(100)]
        public string raktar_helye { get; set; }
        public DateTime? Berlesi_ido { get; set; }

        [JsonIgnore]
        [InverseProperty("raktar")]
        public virtual ICollection<Bolt> raktarak { get; set; }
    }
}
