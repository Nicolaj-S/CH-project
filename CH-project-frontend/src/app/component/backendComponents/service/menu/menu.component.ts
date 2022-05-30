import { HttpClient } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { CreateMenu } from '../../interface/Create/IMenuCreate';
import { IMenu } from '../../interface/Model/IMenu';
@Injectable({
  providedIn: 'root'
})
export class MenuComponent{


  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetMenus():Observable<IMenu[]>{
      return this.http.get<IMenu[]>(this.ApiUrl)
    }

    GetMenuById(Id:number):Observable<IMenu>{
      return this.http.get<IMenu>(`${this.url}/Menu/${Id}`)
    }

    GetMenuByName(ItemName : string):Observable<IMenu>{
      return this.http.get<IMenu>(`${this.url}/Menu/${ItemName}`)
    }

    create(data:any):Observable<CreateMenu>{
      return this.http.post<CreateMenu>(`${this.url}Menu`, data)
    }

    update(Id:number, change:IMenu){
      this.http.patch(`${this.url}/Menu/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IMenu>{
      return this.http.delete<IMenu>(`${this.url}Menu/${Id}`)
    }

}
