import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
//import { url } from 'inspector';
import { BidDetail } from '../Models/BidDetail.model';
import { ProductService } from '../product.service'

@Component({
  selector: 'app-product-biddetails-list',
  templateUrl: './product-biddetails-list.component.html',
  styleUrls: ['./product-biddetails-list.component.css']
})
export class ProductBiddetailsListComponent implements OnInit {

  bids: BidDetail[];
  productId: number;

  title = "Product Bid Details List";

  constructor(private route: ActivatedRoute,
    private productService: ProductService) {
    this.bids = [];
    this.productId = 0;
  }

  ngOnInit(): void {
    debugger;
    this.route.url.subscribe(params => {
      debugger;
      this.productId =parseInt( params[params.length-1]["path"],0);
    });
   
    this.productService.GetBidList(this.productId).subscribe((data: any) => {
      debugger;
      data.forEach((val: any) => { this.bids.push(new BidDetail(val)) });
    });

  }

}
