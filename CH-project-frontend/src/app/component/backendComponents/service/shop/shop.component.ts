import { HttpClient } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { CreateShop } from '../../interface/Create/IShopCreate';
import { IShop } from '../../interface/Model/IShop';
@Injectable({
  providedIn: 'root'
})
export class ShopComponent{

  
  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetShops():Observable<IShop[]>{
      return this.http.get<IShop[]>(this.ApiUrl)
    }

    GetShop(Id:number):Observable<IShop>{
      return this.http.get<IShop>(`${this.url}/Shop/${Id}`)
    }

    create(data:any):Observable<CreateShop>{
      return this.http.post<CreateShop>(`${this.url}Shop`, data)
    }

    update(Id:number, change:IShop){
      this.http.patch(`${this.url}/Shop/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IShop>{
      return this.http.delete<IShop>(`${this.url}Shop/${Id}`)
    }

}
