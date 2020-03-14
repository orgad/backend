using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/invt/")]
    [EnableCors("any")]
    public class InvtController : ApiController
    {
        InventoryService inventoryService = new InventoryService();
        InventoryDetailService inventoryDetailService = new InventoryDetailService();
        InventoryLogService inventoryLogService = new InventoryLogService();

        [Route("list")]
         public JsonResult List(QueryInvt queryInvt)
         {
             return new JsonResult(new SingleResponse{
                 TotalCount = inventoryService.TotalCount(queryInvt),
                 Data = inventoryService.PageList(queryInvt)
             });
         }

          [Route("details")]
          public JsonResult Details(QueryInvt queryInvt)
          {
              var result = inventoryDetailService.PageList(queryInvt);
              var totalCount = inventoryDetailService.TotalCount(queryInvt);
              return new JsonResult(new SingleResponse{
                  Data = result,
                  TotalCount = totalCount
              });
          }

         [Route("detail-list")]
         public JsonResult DetailList(QueryInvt queryInvt)
         {
             return new JsonResult(new SingleResponse{
                 TotalCount = inventoryDetailService.TotalCount(queryInvt),
                 Data = inventoryDetailService.PageList(queryInvt)
             });
         }

         [Route("log-list")]
         public JsonResult LogList(QueryInvt queryInvt)
         {
             return new JsonResult(new SingleResponse{
                 TotalCount = inventoryLogService.TotalCount(queryInvt),
                 Data = inventoryLogService.PageList(queryInvt)
             });
         }
    }
}