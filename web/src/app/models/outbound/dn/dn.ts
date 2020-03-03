interface Dn {
    id: number,
    code: string,
    batchNo: string,
    custId: string,
    refNo: string,
    transCode: string,
    srcCode: string,
    status: string,
    expectAt: Date,
    detailDTOList: DnDetail[]
}