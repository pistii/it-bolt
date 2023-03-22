using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    public partial class Gyarto
    {
        public Gyarto()
        {
            eszkoz = new HashSet<Eszkoz>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int? gyartoID { get; set; }
        [StringLength(50)]
        public string? gyarto_neve { get; set; }
        [StringLength(50)]
        public string? gyarto_szekhelye { get; set; }

        [JsonIgnore]
        [InverseProperty("gyarto")]
        public virtual ICollection<Eszkoz> eszkoz { get; set; }
    }
}
