using System.Web.Http;
using dotnet_wms_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/qc/mobile/")]
    public class QcMobileController:ApiController
    {
        QcService qcService = new QcService();
        //质检单查询
        //质检任务详情
        //质检任务查询
        //质检扫描
        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri] long id,[FromBody]TInQcD qcD)
        {
            qcService.Scan(id,qcD);
            return new JsonResult(true);
        }

        //质检拍照

        //质检扫描完成
        public JsonResult Finished([FromUri]long id)
        {
            qcService.Done(id);
            return new JsonResult(true);
        }
    }
}