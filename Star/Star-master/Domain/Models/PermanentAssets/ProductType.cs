using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PermanentAssets
{
     public class ProductType
    {
        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public int ParentProductTypeId { get; set; }

        public virtual List<Product> Product { get; set; }

    }
}
