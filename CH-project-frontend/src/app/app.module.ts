import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { ErrorPageComponent } from './component/error-page/error-page.component';
import { BlogComponent } from './component/blog/blog.component';
import { RecipesComponent } from './component/Recipes-component/recipes/recipes.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { AdminPanelComponent } from './component/admin-panel/admin-panel.component';
import { RecipesDetailComponent } from './component/Recipes-component/recipes-detail/recipes-detail.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { UserPanelComponent } from './component/user-panel/user-panel.component';
import { MenuComponent } from './component/Menu-component/menu/menu.component';
import { MenuDetailComponent } from './component/Menu-component/menu-detail/menu-detail.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ErrorPageComponent,
    BlogComponent,
    RecipesComponent,
    LoginComponent,
    RegisterComponent,
    AdminPanelComponent,
    RecipesDetailComponent,
    UserPanelComponent,
    MenuComponent,
    MenuDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    FontAwesomeModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSkeletonLoaderModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
