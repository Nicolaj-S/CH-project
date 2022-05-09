import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
import { CartComponent } from './component/Shop-component/cart/cart.component';

const routes: Routes = [
  //primary used router links
  {path:'', redirectTo:'/Home', pathMatch:'full'},
  {path:'Home',component:HomeComponent},
  {path:'Blog', component:BlogComponent},
  {path:'Recipes', component:RecipesComponent, 
  children:[
    {path:'Recipes/:Id', component:RecipesDetailComponent}
  ]},
  {path:'Shop', component:ShopComponent, 
  children:[
    {path:'Shop/:Id', component:ShopDetailComponent},
    {path:'Shop/Cart', component:CartComponent}
  ]},
  
  

  //login/register router links
  {path:'Login', component:LoginComponent},
  {path:'Register', component:RegisterComponent},

  //admin panel router link
  {path:'AdminPanel', component:AdminPanelComponent},

  //Error page default link when theres a problem with the route
  {path:'**', component:ErrorPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
