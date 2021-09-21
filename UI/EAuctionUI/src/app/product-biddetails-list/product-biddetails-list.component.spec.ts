import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductBiddetailsListComponent } from './product-biddetails-list.component';

describe('ProductBiddetailsListComponent', () => {
  let component: ProductBiddetailsListComponent;
  let fixture: ComponentFixture<ProductBiddetailsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductBiddetailsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductBiddetailsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
