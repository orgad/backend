using System.Collections.Generic;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VRcvScan : VScanRequest
    {
        public string QcCode{get;set;}
    }
}