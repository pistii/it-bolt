using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ItBolt.Model.Entities
{
    [Table("leltarieszkozok")]
    public partial class Leltarieszkoz
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int eszkozID { get; set; }
        [Key]
        [StringLength(25)]
        public string boltID { get; set; } = null!;
        [StringLength(25)]
        public string? leltariszam { get; set; }


    }
}
