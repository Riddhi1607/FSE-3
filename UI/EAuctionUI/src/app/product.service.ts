import { Injectable } from '@angular/core';
import { Product } from './Models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) {

  }

  GetProductList(): any {
    debugger;
    return this.http.get<any>('http://localhost:61957/SellerProduct/GetAllProduct');
  }

  GetBidList(productID: number): any {
    debugger;
    return this.http.get<any>('http://localhost:61957/SellerProduct/GetAllBidsForProduct/' + productID);
  }

}
