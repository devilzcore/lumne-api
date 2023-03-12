import { environment } from 'src/environments/environment';

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog-login',
  templateUrl: './blog-login.component.html',
  styleUrls: ['./blog-login.component.scss']
})
export class BlogLoginComponent implements OnInit {
  public loginForm !: FormGroup

  private httpOptions = {
    headers: new HttpHeaders({
       'Content-Type': 'application/json',
     }),
    withCredentials: false,
  };

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: [''],
      password: ['', Validators.required]
    })
  }

  login() {
    const data = {
      username: this.loginForm.value.username,
      password: this.loginForm.value.password
    }

    this.http.post<any>(`${environment.apiUrl}Authenticate/login`, data, this.httpOptions)
      .subscribe(res =>
      { return console.log(res)},
        (error) => { console.error(error) })
  }
}
