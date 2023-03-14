import { AuthenticationService } from './../../services/auth.service';
import { Category } from './../../models/category';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Post } from 'src/models/post';
import { User } from 'src/models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.scss']
})
export class BlogPostComponent implements OnInit {
  category = {} as Category
  categories: Category[] = []

  postForm!: FormGroup

  currentUser?: User

  constructor(
    private formBuilder: FormBuilder,
    private categoryService: DataService,
    private postService: DataService,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.postForm = this.formBuilder.group({
      title: ['', Validators.required],
      image: [''],
      summary: [''],
      content: ['']
    })

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x)
  }

  ngOnInit() {
    this.getCategories()
  }

  getCategories() {
    this.categoryService.getAllCategories()
      .subscribe((categories: Category[]) => {
        this.categories = categories
        console.log(categories)
      })
  }

  onSubmit() {
    const post: Post = {
      title: this.postForm.controls['title'].value,
      content: this.postForm.controls['content'].value,
      categories: []
    }

    this.postService.savePost(post)
      .subscribe(post => {
        console.log('Save..')
        this.postForm.reset()
    })
  }

  logout() {
    this.authenticationService.logout()
    this.router.navigate(['/login'])
  }
}
