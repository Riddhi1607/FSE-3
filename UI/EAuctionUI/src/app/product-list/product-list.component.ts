import { Component, OnInit } from '@angular/core';
import { Product } from '../Models/product.model';
import { Router } from "@angular/router";
import { ProductService } from '../product.service'


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  title = "Product List";
  products: Product[];

  constructor(private router: Router,
    private productService: ProductService) {
    this.products = [];
  }

  ngOnInit(): void {
    this.productService.GetProductList().subscribe((data: any) => {
      debugger;
      data.forEach((val: any) => { this.products.push(new Product(val)) });
    });
  }

  ShowBids(productID: number): void {
    this.router.navigate(['product-bid-list', productID])
  }

}
