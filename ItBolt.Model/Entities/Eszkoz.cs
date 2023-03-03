
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
        [StringLength(25)]
        public string eszkozID { get; set; } = null!;
        [StringLength(25)]
        public string gyartoID { get; set; } = null!;
        [StringLength(25)]
        public string rendelesID { get; set; } = null!;
        [StringLength(50)]
        public string eszkoz_neve { get; set; } = null!;
        [Column(TypeName = "int(11)")]
        public int? eszkoz_ara { get; set; }
        [StringLength(25)]
        public string eszkoz_sorozatszama { get; set; } = null!;

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly? eszkoz_gyartas_ev { get; set; }
        [StringLength(25)]
        public string kategoriaID { get; set; } = null!;
        [Column(TypeName = "int(11)")]
        public int? raktar_keszlet { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? garancialis_e { get; set; }
        [Column(TypeName = "bit(1)")]
        public ulong? kedvezmenyes_e { get; set; }
        [StringLength(50)]
        public string eszkoz_tipus { get; set; } = null!;

        [ForeignKey("gyartoID")]
        [InverseProperty("eszkoz")]
        public virtual Gyarto? gyarto { get; set; }
        [ForeignKey("kategoriaID")]
        [InverseProperty("eszkoz")]
        public virtual Kategoria? kategoria { get; set; }
    }
}
