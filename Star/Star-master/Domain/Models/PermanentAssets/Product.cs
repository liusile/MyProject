using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PermanentAssets
{
    public class Product
    {
        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductTypeId { get; set; }
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdcutId { get; set; }
        [Key]
        [Column(Order = 4)]
        public string ProductName { get; set; }
        public string ProductImgUrl { get; set; }
        public string Introduce { get; set; }
        public string  Remark { get; set; }
    }
}
