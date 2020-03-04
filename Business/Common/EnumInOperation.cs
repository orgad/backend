namespace dotnet_wms_ef
{
    public enum EnumInOperation
    {
        None,
        
        Notice, //到货

        Check,  //验货

        Receiving,//收货

        Qc,//质检

        PutAway,//上架
    }
}