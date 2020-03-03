/*查询用*/
interface Asn
{
    code :string;
    batchNo:string;
    whId :number;
    custId :number;
    brandId :number;
    bizCode:string;
    goodsType:string;
    invoiceNo :string;
    isCiq :boolean;
    detailList:AsnDetail[];
    ciqDetailList:AsnCiqDetail[];
}