namespace dotnet_wms_ef.ViewModels
{
    public class VResult
    {
        //本次操作是否成功:针对执行的结果:如果是批量操作,部分成功返回false
        public bool Success{get;set;}

        //本次操作返回的附加信息:如[{Id:XXX,Code:XXX,Success:XXX,Message}],可以是一个或者多个
        public object Data{get;set;}
        
        //本次操作返回的结果
        public string Message{get;set;}
    }
}