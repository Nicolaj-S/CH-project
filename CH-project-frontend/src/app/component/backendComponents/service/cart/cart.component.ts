import { HttpClient } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';

import { CreateCart } from '../../interface/Create/ICartCreate';
import { ICart } from '../../interface/Model/ICart';

@Injectable({
  providedIn: 'root'
})
export class CartComponent{

  
  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }


    GetCart(Id:number):Observable<ICart>{
      return this.http.get<ICart>(`${this.url}/Cart/${Id}`)
    }

    create(data:any):Observable<CreateCart>{
      return this.http.post<CreateCart>(`${this.url}Cart`, data)
    }

    update(Id:number, change:ICart){
      this.http.patch(`${this.url}/Cart/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<ICart>{
      return this.http.delete<ICart>(`${this.url}Cart/${Id}`)
    }

}
