import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { ErrorPageComponent } from './component/error-page/error-page.component';
import { BlogComponent } from './component/blog/blog.component';
import { RecipesComponent } from './component/Recipes-component/recipes/recipes.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { AdminPanelComponent } from './component/admin-panel/admin-panel.component';
import { RecipesDetailComponent } from './component/Recipes-component/recipes-detail/recipes-detail.component';
import { UserPanelComponent } from './component/user-panel/user-panel.component';
import { MenuComponent } from './component/Menu-component/menu/menu.component';
import { MenuDetailComponent } from './component/Menu-component/menu-detail/menu-detail.component';

const routes: Routes = [
  //redirect to homepage
  {path:'', redirectTo:'/Home', pathMatch:'full'},

  //primary used router links
  {path:'Home',         component:HomeComponent},
  {path:'Blog',         component:BlogComponent},
  {path:'Recipes',      component:RecipesComponent},
  {path:'Recipes/:Id',  component:RecipesDetailComponent},
  {path:'Menu',         component:MenuComponent},
  {path:'Menu/:Id',     component:MenuDetailComponent},

  //login/register router links
  {path:'Login',        component:LoginComponent},
  {path:'Register',     component:RegisterComponent},

  //admin and user panel router link
  {path:'AdminPanel',   component:AdminPanelComponent},
  {path:'User/:Id',     component:UserPanelComponent},

  //Error page default link when theres a problem with the route
  {path:'**',           component:ErrorPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
