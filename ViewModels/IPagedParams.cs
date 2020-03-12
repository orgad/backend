namespace dotnet_wms_ef.ViewModels
{
    public abstract class PagedParams
    {
        public int PageIndex{get;set;}

        public int PageSize{get;set;}
    }
}