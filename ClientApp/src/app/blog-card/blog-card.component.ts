import { DataService } from './../../services/data.service';
import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../../models/post'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-blog-card',
  templateUrl: './blog-card.component.html',
  styleUrls: ['./blog-card.component.scss']
})

export class BlogCardComponent {
  @Input() post!: Post

  postUrl : string | undefined

  constructor() { }

  ngOnInit() {
    this.postUrl = `/posts/${this.post.id}`
  }
}
