using System;
using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Aop
{
    public class LogHandlerAttribute 
    {

        public long OrderId { set; get; }
        public string OrderCode { get; set; }
        public string Status { get; set; }

        wmsinboundContext wmsinbound;

        public LogHandlerAttribute(DbContext db)
        {
            this.wmsinbound = (wmsinboundContext)db;
        }

        public void OrderStatusChange()
        {
            this.orderStatusLog(this.OrderId,this.OrderCode,null,this.Status);
        }

        private void orderStatusLog(long id,string code,string typeCode,string status)
        {
            TInLog log = new TInLog{
                OrderId = id,
                OrderCode = code,
                OptCode = status,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };
            wmsinbound.TInLogs.Add(log);
        }
    }
}