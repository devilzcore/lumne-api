import { AuthenticationService } from './../../services/auth.service';
import { Category } from './../../models/category';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Post } from 'src/models/post';
import { User } from 'src/models/user';
import { Router } from '@angular/router';
import { map, catchError, of } from 'rxjs';

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
      id: ['0'],
      title: ['', Validators.required],
      image: [''],
      summary: [''],
      content: [''],
      category: ['']
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

  post() {
    const categories: Category[] = [{
      name: this.postForm.controls['category'].value
    }];

    const post: Post = {
      id: this.postForm.controls['id'].value,
      title: this.postForm.controls['title'].value,
      image: this.postForm.controls['image'].value,
      content: this.postForm.controls['content'].value,
      categories: categories
    }

    return post
  }

  savePost() {
    this.postService.savePost(this.post())
      .subscribe(post => {
        console.log('Save..', post)
        this.postForm.reset()
      })
  }

  updatePost() {
    this.postService.getPostId(this.post().id!)
      .subscribe((post) => {
        this.postService.updatePost(post)
          .subscribe(post => { console.log('Edit..', post) })
      })
  }

  deletePost() {
    this.postService.deletePost(this.post())
      .subscribe(post => console.log('deleted..', post))
  }

  logout() {
    this.authenticationService.logout()
    this.router.navigate(['/login'])
  }
}
