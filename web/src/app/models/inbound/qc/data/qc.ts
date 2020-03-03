interface Qc {
    id: number,
    inboundId: number,
    code: string,
    firstScanAt: Date,
    lastScanAt: Date,
    status: string,
    createdBy: string,
    createdTime: Date,
    lastModifiedBy: string,
    lastModifiedTime: Date,
    qcDetails: QcDetail[]
}