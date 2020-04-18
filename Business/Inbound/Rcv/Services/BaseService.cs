using dotnet_wms_ef.Inbound.Aop;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.Services
{
    public class BaseService
    {
        protected wmsinboundContext wms;

        protected Log Mapper<T>(T t)
        {
            Log opt = new Log();

            if (t is TInAsn)
            {
                var x = t as TInAsn;
                opt = new Log {Id = x.Id,Code = x.Code,TypeCode = x.TypeCode,Status = x.Status};
            }

            if (t is TInInbound)
            {
                var x = t as TInInbound;
                opt = new Log {Id = x.Id,Code = x.Code,TypeCode = x.TypeCode,Status = x.Status};
            }
            return opt;
        }

        protected Log OptMapper<T>(T t, string optStatus)
        {
            Log opt = new Log();
            if (t is TInAsn)
            {
                var x = t as TInAsn;
                opt = new Log
                {
                    Id = x.Id,Code = x.Code,TypeCode = x.TypeCode,Status = x.Status,OptStatus = optStatus
                };
            }

            if (t is TInInbound)
            {
                var x = t as TInInbound;
                opt = new Log
                {
                    Id = x.Id,Code = x.Code,TypeCode = x.TypeCode,Status = x.Status,OptStatus = optStatus
                };
            }

            return opt;
        }

        protected void setProxy(Log log)
        {
            LogHandlerAttribute logHandler = new LogHandlerAttribute(wms);
            logHandler.OrderId = log.Id;
            logHandler.OrderCode = log.Code;
            logHandler.OrderType = log.TypeCode;
            logHandler.Status = log.Status;
            logHandler.OrderStatusChange();
        }

        protected void setOptProxy(Log log)
        {
            LogHandlerAttribute logHandler = new LogHandlerAttribute(wms);
            logHandler.OrderId = log.Id;
            logHandler.OrderCode = log.Code;
            logHandler.Status = log.Status;
            logHandler.OptStatus = log.OptStatus;
            logHandler.OptStatusChange();
        }
    }
}