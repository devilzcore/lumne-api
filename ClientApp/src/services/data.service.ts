import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Post } from '../models/post'

@Injectable({
  providedIn: 'root'
})

export class DataService {
  url = `{environments.apiUrl}Post`

  constructor(private httpClient: HttpClient) { }

  HttpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  getPosts(): Observable<Post[]> {
    return this.httpClient.get<Post[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  getPostId(id: number): Observable<Post> {
    return this.httpClient.get<Post>(this.url + "/" + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  savePost(post: Post): Observable<Post> {
    return this.httpClient.post<Post>(this.url, JSON.stringify(post), this.HttpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
    )
  }

  updatePost(post: Post): Observable<Post> {
    return this.httpClient.put<Post>(this.url + '/' + post.id, JSON.stringify(post), this.HttpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  deletePost(post: Post) {
    return this.httpClient.delete<Post>(this.url + '/' + post.id, this.HttpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
    )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = ''
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message
    } else {
      errorMessage = `Code error: ${error.status}, ` + `{message: ${error.message}}`
    }

    console.log(errorMessage)
    return throwError(errorMessage)
  }
}



