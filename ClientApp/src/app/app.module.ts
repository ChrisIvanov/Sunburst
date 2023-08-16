import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ShopComponent } from './shop/shop.component';
import { ItemCardComponent } from './items/item-card/item-card.component';
import { ItemPageComponent } from './items/item-page/item-page.component';
import { AuthService } from './services/auth/auth.service';
import { CommonModule } from '@angular/common';
import {CookieService} from 'ngx-cookie-service';
import { CartComponent } from './shop/cart/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ShopComponent,
    ItemCardComponent,
    ItemPageComponent,
    CartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'shop', component: ShopComponent, pathMatch: 'full' },
      { path: 'shop/:name', component: ItemPageComponent, pathMatch: 'full' },
      { path: 'cart', component: CartComponent, pathMatch: 'full' },

      
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    AuthService,
    CookieService,
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
