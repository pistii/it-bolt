using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ItBolt.Model.Entities
{
    //[Index("raktarID", Name = "raktarID")]
    public partial class Bolt
    {
        public Bolt()
        {
            //leltarieszkoz = new HashSet<Leltarieszkoz>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int boltID { get; set; }
        [Column(TypeName = "int(11)")]
        public int? raktarID { get; set; }
        [Column(TypeName = "int(11)")]
        public int? rendelesID { get; set; }
        [StringLength(50)]
        public string? bolt_neve { get; set; }
        [StringLength(100)]
        public string? bolt_cime { get; set; }
        [StringLength(15)]
        public string? nyitvatartasi_ido { get; set; }


        [ForeignKey("raktarID")]
        [InverseProperty("raktarak")]
        [JsonIgnore]
        public virtual Raktar? raktar { get; set; }




    }
}
