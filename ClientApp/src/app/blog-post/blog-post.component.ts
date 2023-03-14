import { DataService } from './../../services/data.service';
import { Category } from 'src/models/category';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.scss']
})
export class BlogPostComponent implements OnInit {
  category = {} as Category
  categories: Category[] = []

  constructor(private categoryService: DataService) { }

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
}
