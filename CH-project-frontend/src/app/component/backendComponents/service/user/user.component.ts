import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IUser } from '../../interface/Model/IUser';
import { CreateUser } from '../../interface/Create/IUserCreate';

@Injectable({
  providedIn: 'root'
})
export class UserComponent {

  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetUsers():Observable<IUser[]>{
      return this.http.get<IUser[]>(this.ApiUrl)
    }

    GetUser(Id:number):Observable<IUser>{
      return this.http.get<IUser>(`${this.url}/User/${Id}`)
    }

    create(data:any):Observable<CreateUser>{
      return this.http.post<CreateUser>(`${this.url}User`, data)
    }

    update(Id:number, change:IUser){
      this.http.patch(`${this.url}/User/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IUser>{
      return this.http.delete<IUser>(`${this.url}User/${Id}`)
    }
}
