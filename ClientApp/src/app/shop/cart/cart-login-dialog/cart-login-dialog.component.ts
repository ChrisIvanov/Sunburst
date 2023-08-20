import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart-login-dialog',
  templateUrl: './cart-login-dialog.component.html',
  styleUrls: ['./cart-login-dialog.component.css']
})
export class CartLoginDialogComponent {

  constructor(
    private dialogRef: MatDialogRef<CartLoginDialogComponent>,
    private router: Router
  ) {}

  redirectToLogin(): void {
    this.dialogRef.close();
    this.router.navigate(['authentication/login']);
  }

  cancel(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void { }
}
