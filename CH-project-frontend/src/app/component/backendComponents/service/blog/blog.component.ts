import { HttpClient } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';

import { CreateBlog } from '../../interface/Create/IBlogCreate';
import { IBlog } from '../../interface/Model/IBlog';

@Injectable({
  providedIn: 'root'
})
export class BlogComponent {

  public ApiUrl = "--<insert Url to api item>--";
  url: string = "--<insert api url>--";


  constructor(
    private http:HttpClient
  ) { }

    GetBlogs():Observable<IBlog[]>{
      return this.http.get<IBlog[]>(this.ApiUrl)
    }

    create(data:any):Observable<CreateBlog>{
      return this.http.post<CreateBlog>(`${this.url}Blog`, data)
    }

    update(Id:number, change:IBlog){
      this.http.patch(`${this.url}/Blog/${Id}`, change).subscribe({ error: console.error, complete:console.info});
    }

    delete(Id:number):Observable<IBlog>{
      return this.http.delete<IBlog>(`${this.url}Blog/${Id}`)
    }

}
