using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    internal class QcService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        private IQueryable<TInQc> Query(QueryQc queryQc)
        {
            return wmsinbound.TInQcs;
        }

        public List<TInQc> PageList(QueryQc queryQc)
        {
            return this.Query(queryQc).
            OrderByDescending(x => x.Id).Skip(queryQc.pageIndex).Take(queryQc.pageSize).ToList();
        }

        public int TotalCount(QueryQc queryQc)
        {
            return this.Query(queryQc).Count();
        }

        public VQc Details(long id)
        {
            var o = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();

            var ds = wmsinbound.TInQcDs.Where(x => x.HId == id).ToList();

            return new VQc { Qc = o, QcDs = ds.Any() ? ds.ToArray() : null };
        }

        public bool Scan(long id, TInQcD qcD)
        {
            qcD.HId = id;
            qcD.CreatedBy = DefaultUser.UserName;
            qcD.CreatedTime = DateTime.UtcNow;
            wmsinbound.TInQcDs.Add(qcD);
            
            Doing(id);
            
            return true;
        }

        private bool Doing(long id)
        {
            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
            return wmsinbound.SaveChanges()>0;
        }

        public bool Done(long id)
        {
            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
            return wmsinbound.SaveChanges()>0;
        }

        public bool Confirm(long[] ids)
        {
            foreach (var id in ids)
            {
                Confirm(id);
            }

            return true;
        }

        private bool Confirm(long id)
        {
            //更新质检单的状态和入库单的质检状态
            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == qc.InboundId).FirstOrDefault();
            inbound.QcStatus = qc.Status;

            wmsinbound.SaveChanges();

            return true;
        }
    }
}