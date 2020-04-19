using System.Collections.Generic;
using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VPreQcDetails
    {
        public TInPreQc PreQc{get;set;}
        public ICollection<TInPreQcD> DetailList{get;set;}
    }
}