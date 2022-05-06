import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { ErrorPageComponent } from './component/error-page/error-page.component';
import { BlogComponent } from './component/blog/blog.component';
import { RecipesComponent } from './component/Recipes-component/recipes/recipes.component';
import { ShopComponent } from './component/Shop-component/shop/shop.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { AdminPanelComponent } from './component/admin-panel/admin-panel.component';
import { RecipesDetailComponent } from './component/Recipes-component/recipes-detail/recipes-detail.component';
import { ShopDetailComponent } from './component/Shop-component/shop-detail/shop-detail.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ErrorPageComponent,
    BlogComponent,
    RecipesComponent,
    ShopComponent,
    LoginComponent,
    RegisterComponent,
    AdminPanelComponent,
    RecipesDetailComponent,
    ShopDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
