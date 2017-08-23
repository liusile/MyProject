using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class SysFlowNo
    {
        public int Id { get; set; }
        public string FlowNo { get; set; }
        public FlowNoType FlowNoType { get; set; }
        public string Time { get; set; }

        public string GetNextFlowNo()
        {
            return (int.Parse(FlowNo) + 1).ToString().PadLeft(4, '0');
        }
    }

    public enum FlowNoType
    {
        Stock
    }
}
