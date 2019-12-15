import { Injectable } from '@angular/core';
import {HttpClient} from  '@angular/common/http';
import { Post } from '../models/post';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private postUrl='https://localhost:44321/api/posts';

  constructor(
    private http: HttpClient
  ) { }

  getPosts():Observable<Post[]>{
    return this.http.get<Post[]>(this.postUrl);
  }
}
