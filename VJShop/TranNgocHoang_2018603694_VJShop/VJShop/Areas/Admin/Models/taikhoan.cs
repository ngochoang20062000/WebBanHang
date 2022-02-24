namespace VJShop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taikhoan")]
    public partial class taikhoan
    {
        [Key]
        [StringLength(10)]
        public string MaTK { get; set; }

        [StringLength(50)]
        public string TenDN { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Quyen { get; set; }
    }
}
