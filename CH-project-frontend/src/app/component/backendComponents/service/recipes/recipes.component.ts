import { HttpClient } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { CreateRecipe } from '../../interface/Create/IRecipesCreate';
import { IRecipes } from '../../interface/Model/IRecipes';

@Injectable({
  providedIn: 'root'
})
export class RecipesComponent{

  
  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetRecipes():Observable<IRecipes[]>{
      return this.http.get<IRecipes[]>(this.ApiUrl)
    }

    GetRecipe(Id:number):Observable<IRecipes>{
      return this.http.get<IRecipes>(`${this.url}/Recipes/${Id}`)
    }

    create(data:any):Observable<CreateRecipe>{
      return this.http.post<CreateRecipe>(`${this.url}Recipes`, data)
    }

    update(Id:number, change:IRecipes){
      this.http.patch(`${this.url}/Recipes/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IRecipes>{
      return this.http.delete<IRecipes>(`${this.url}Recipes/${Id}`)
    }

}
