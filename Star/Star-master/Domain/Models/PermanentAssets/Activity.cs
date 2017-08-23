using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PermanentAssets
{
    public class Activity
    {
        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }

        public string Subject { get; set; }
        public DateTime Time { get; set; }
        public string Remark { get; set; }
    }
}
