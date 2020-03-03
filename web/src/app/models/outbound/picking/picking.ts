interface Picking
{
    id: number,
    code: string,
    whId: number,
    waveId: number,
    outboundId: number,
    store: number,
    binQty: number,
    cartonQty: number,
    qty: number,
    firstScanAt: Date,
    lastScanAt: Date,
    comment: string,
    isCancel: false,
    isConfirm: false,
    printAt: Date,
    createdBy: string,
    createdTime: Date,
    lastModifiedBy: string,
    lastModifiedTime: Date,
    detailDTO:PickingDetail[];
}