
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    public partial class Vasarlas
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int? vasarloID { get; set; }
        [Column(TypeName = "int(11)")]
        public int rendelesID { get; set; }
        [StringLength(25)]
        public string? fizetesmod { get; set; } = null!;

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly? vasarlas_datuma { get; set; } = null!;
        [StringLength(25)]
        public string? vasarlas_tipusa { get; set; } = null!;
        [StringLength(50)]
        public string? szamlazasi_cim { get; set; } = null!;
        [StringLength(50)]
        public string szallitasi_cim { get; set; } = null!;

        [JsonIgnore]
        [ForeignKey("vasarloID")]
        [InverseProperty("vasarlas")]
        public virtual Vasarlo? vasarlo { get; set; }
    }


}
