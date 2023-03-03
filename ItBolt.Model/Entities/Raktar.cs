using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItBolt.Model.Entities
{
    public partial class Raktar
    {
        public Raktar()
        {
            bolt = new HashSet<Bolt>();
        }

        [Key]
        [StringLength(25)]
        public string raktarID { get; set; } = null!;
        [StringLength(50)]
        public string? raktar_neve { get; set; }
        [StringLength(100)]
        public string? bolt_helye { get; set; }
        public DateOnly? Berlesi_ido { get; set; }

        [InverseProperty("raktar")]
        public virtual ICollection<Bolt> bolt { get; set; }
    }
}
