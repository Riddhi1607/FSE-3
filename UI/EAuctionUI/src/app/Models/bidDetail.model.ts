export class BidDetail {
    public BuyerEmail: string;
    public BuyerName: string;
    public BidAmount: number;

    constructor(data: any) {
        this.BuyerEmail = data ? data.BuyerEmail : 0;
        this.BuyerName = data ? data.BuyerFirstName + " " + data.BuyerLastName : "";
        this.BidAmount = data ? data.BuyersBidAmount : "";
    }
}
