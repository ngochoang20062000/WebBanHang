namespace VJShop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMMAYANH")]
    public partial class DMMAYANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMMAYANH()
        {
            MAYANHs = new HashSet<MAYANH>();
        }

        [Key]
        [StringLength(20)]
        public string MaDM { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [Column(TypeName = "text")]
        public string AnhDaiDien { get; set; }

        public int? GiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAYANH> MAYANHs { get; set; }
    }
}
