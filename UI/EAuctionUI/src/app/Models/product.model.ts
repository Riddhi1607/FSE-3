export class Product {
    public ID: number;
    public Name: string;
    public ShortDescription: string;
    public DetailedDescription: string;
    public Category: string;
    public StartingPrice: number;
    public BidEndDate: string;
    public SellerName: string;

    constructor(data: any) {
        this.ID = data ? data.ProductId : 0;
        this.Name = data ? data.ProductName : "";
        this.ShortDescription = data ? data.ProductShortDescription : "";
        this.DetailedDescription = data ? data.ProductDetailedDescription : "";
        this.Category = data ? data.Category : "";
        this.StartingPrice = data ? data.StartingBid : 0;
        this.BidEndDate = data ? data.BidEndDate : "";
        this.SellerName = data ? (data.SellerFirstName +
             " " + data.SellerLastName) : "";
    }
}
