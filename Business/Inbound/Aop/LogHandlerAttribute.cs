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
        public string OrderType { get; set; }
        public string OptStatus { get; set; }

        wmsinboundContext wmsinbound;

        public LogHandlerAttribute(DbContext db)
        {
            this.wmsinbound = (wmsinboundContext)db;
        }

        public void OrderStatusChange()
        {
            this.orderStatusLog(this.OrderId, this.OrderCode, this.OrderType, this.Status);
        }

        public void OptStatusChange()
        {
            this.optStatusLog(this.OrderId, this.OrderCode, this.Status, this.OptStatus);
        }

        private void orderStatusLog(long id, string code, string typeCode, string status)
        {
            TInLog log = new TInLog
            {
                OrderId = id,
                OrderCode = code,
                OptCode = status,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };
            wmsinbound.TInLogs.Add(log);
        }

        private void optStatusLog(long id, string code, string status, string optStatus)
        {
            TInOptlog log = new TInOptlog
            {
                OrderId = id,
                OrderCode = code,
                OrderStatus = status,
                OptStatus = optStatus,
                IsDeleted = false,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };
            wmsinbound.TInOptlogs.Add(log);
        }
    }
}