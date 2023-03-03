
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    public partial class Vasarlo
    {
        public Vasarlo()
        {
            vasarlas = new HashSet<Vasarlas>();
        }

        [Key]
        [StringLength(25)]
        public string vasarloID { get; set; } = null!;
        [StringLength(50)]
        public string? vasarlo_neve { get; set; }
        [Column(TypeName = "int(10)")]
        public int? vasarlo_telefonszama { get; set; }
        [StringLength(25)]
        public string? vasarlo_emailcime { get; set; }

        [JsonIgnore]
        [InverseProperty("vasarlo")]
        public virtual ICollection<Vasarlas> vasarlas { get; set; }
    }
}
