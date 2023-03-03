using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ItBolt.Model.Entities
{
    public partial class Leltarieszkoz
    {
        [Key]
        [StringLength(25)]
        public string eszkozID { get; set; } = null!;
        [Key]
        [StringLength(25)]
        public string boltID { get; set; } = null!;
        [StringLength(25)]
        public string? leltariszam { get; set; }

        [JsonIgnore]
        [ForeignKey("boltID")]
        [InverseProperty("leltarieszkoz")]
        public virtual Bolt? bolt { get; set; }
    }
}
