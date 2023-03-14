import { Category } from './../../models/category';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Post } from 'src/models/post';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.scss']
})
export class BlogPostComponent implements OnInit {
  category = {} as Category
  categories: Category[] = []

  postForm!: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private categoryService: DataService,
    private postService: DataService
  ) {
    this.postForm = this.formBuilder.group({
      title: ['', Validators.required],
      image: [''],
      summary: [''],
      content: ['']
    })
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

}
