namespace VJShop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAYANH")]
    public partial class MAYANH
    {
        [Required(ErrorMessage ="Mã máy ảnh không được để trống!")]
        [Key]
        [StringLength(20)]
        public string MaAnh { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        [StringLength(50)]
        public string TieuDe { get; set; }

        [Column(TypeName = "text")]
        public string AnhDaiDien { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [DisplayName("Giá bán")]
        public int? GiaBan { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống!")]
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống!")]
        public string MoTa { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDM { get; set; }

        public virtual DMMAYANH DMMAYANH { get; set; }
    }
}
