using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public partial class SysFlowNoManage
    {
        public string GetFlowNo(FlowNoType stock)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd");
            var entity = this.LoadAll(o => o.FlowNoType == FlowNoType.Stock).FirstOrDefault();
            if (entity == null)
            {
                this.Save(new SysFlowNo()
                {
                    FlowNoType=FlowNoType.Stock,
                    FlowNo="1",
                    Time= now
                });
                return "1";
            }
            else
            {
                entity.FlowNo = (Convert.ToInt32(entity.FlowNo) + 1).ToString().PadLeft(4,'0');
                this.Update(entity);
                return entity.FlowNo;
            }
        }
    }
}
