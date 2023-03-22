
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{

    public partial class Eszkoz
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int eszkozID { get; set; }
        [Column(TypeName = "int(11)")]
        public int gyartoID { get; set; }
        [StringLength(50)]
        public string? eszkoz_neve { get; set; }
        [Column(TypeName = "int(11)")]
        public int? eszkoz_ara { get; set; }
        [StringLength(50)]
        public string? eszkoz_sorozatszama { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly? eszkoz_gyartas_ev { get; set; }
        [Column(TypeName = "int(11)")]

        public int kategoriaID { get; set; }
        [Column(TypeName = "int(11)")]
        public int? raktar_keszlet { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? garancialis_e { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? kedvezmenyes_e { get; set; }
        [StringLength(50)]
        public string eszkoz_tipus { get; set; } = null!;
        [JsonIgnore]
        [ForeignKey("gyartoID")]
        [InverseProperty("eszkoz")]
        public virtual Gyarto? gyarto { get; set; }
        [ForeignKey("kategoriaID")]
        [InverseProperty("eszkoz")]
        [JsonIgnore]
        public virtual Kategoria? kategoria { get; set; }
    }
}
