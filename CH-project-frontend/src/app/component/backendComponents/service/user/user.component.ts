import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IUser } from '../../interface/Model/IUser';
import { CreateUser } from '../../interface/Create/IUserCreate';
import { AuthenticateRequest } from '../../interface/Model/IAuthenticateRequest';
import { IRefreshToken } from '../../interface/Model/IRefreshToken';
import { RevokeTokenRequest } from '../../interface/Model/IRevokeTokenRequest';

@Injectable({
  providedIn: 'root'
})
export class UserComponent {

  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetAllUsers():Observable<IUser[]>{
      return this.http.get<IUser[]>(this.ApiUrl)
    }

    GetUserByUsername(Username : string):Observable<IUser[]>{
      return this.http.get<IUser[]>(`${this.url}/Username/${Username}`)
    }

    GetUserById(Id:number):Observable<IUser>{
      return this.http.get<IUser>(`${this.url}/${Id}`)
    }

    create(data:any):Observable<CreateUser>{
      return this.http.post<CreateUser>(`${this.url}/`, data)
    }

    update(Id:number, change:IUser){
      this.http.patch(`${this.url}/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IUser>{
      return this.http.delete<IUser>(`${this.url}/${Id}`)
    }

    Authenticate(model:any):Observable<AuthenticateRequest>{
      return this.http.post<AuthenticateRequest>(`${this.ApiUrl}/authenticate`, model);
    }

    RefreshToken(model: any): Observable<IRefreshToken>{
      return this.http.post<IRefreshToken>(`${this.ApiUrl}/refresh-token`, model)
    }

    RevokeToken(model: any): Observable<RevokeTokenRequest>{
      return this.http.post<RevokeTokenRequest>(`${this.ApiUrl}/revoke-token`, model)
    }

    GetRefreshTokens(id : number):Observable<IUser>{
      return this.http.get<IUser>(`${this.ApiUrl}/${id}/refresh-tokens`)
    }

  }
