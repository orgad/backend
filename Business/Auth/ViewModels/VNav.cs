using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VNav
    {
        public string Title{get;set;}
        public ICollection<VNavSub> Children {get;set;}
    }

    public class VNavSub
    {
        public string Title{get;set;}
        public string Router{get;set;}
    }
}