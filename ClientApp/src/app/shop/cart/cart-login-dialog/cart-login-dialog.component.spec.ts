import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartLoginDialogComponent } from './cart-login-dialog.component';

describe('CartLoginDialogComponent', () => {
  let component: CartLoginDialogComponent;
  let fixture: ComponentFixture<CartLoginDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartLoginDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CartLoginDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
