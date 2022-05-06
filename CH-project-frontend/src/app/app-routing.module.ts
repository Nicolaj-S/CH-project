import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { ErrorPageComponent } from './component/error-page/error-page.component';
import { BlogComponent } from './component/blog/blog.component';
import { RecipesComponent } from './component/recipes/recipes.component';
import { ShopComponent } from './component/shop/shop.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';

const routes: Routes = [
  //primary used router links
  {path:'Blog', component:BlogComponent},
  {path:'Recipes', component:RecipesComponent},
  {path:'Shop', component:ShopComponent},
  {path:'Home',component:HomeComponent},
  {path:'', redirectTo:'/Home', pathMatch:'full'},

  //secondary used router links
  {path:'Login', component:LoginComponent},
  {path:'Register', component:RegisterComponent},
  {path:'**', component:ErrorPageComponent, data:{title:'Coffee brake'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
