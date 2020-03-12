namespace dotnet_wms_ef
{
    public class QueryAsnCheck
    {
        public int? whId{get;set;}

        public int custId{get;set;}
        
        public int brandId{get;set;}
        public string asnCode{get;set;}

        public string bizCode{get;set;}

        public string goodsType{get;set;}

        public string status{get;set;}

        public string checkStatus{get;set;}

        public bool? isCiq{get;set;}

        public int pageIndex {get;set;}

        public int pageSize{get;set;}
    }
}