import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BlogHomeComponent } from './blog-home/blog-home.component';
import { BlogLoginComponent } from './blog-login/blog-login.component';
import { BlogPostComponent } from './blog-post/blog-post.component';
import { BlogCardComponent } from './blog-card/blog-card.component';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AuthGuard } from 'src/helpers/auth.guard';

const routes: Routes = [
  { path: '', component: BlogHomeComponent },
  { path: 'login', component: BlogLoginComponent },
  { path: 'post', component: BlogPostComponent, canActivate: [AuthGuard] },
  { path: 'posts/:id', component: BlogPostsComponent },
  { path: 'posts/:id/:title?', component: BlogPostsComponent },
  { path: 'card', component: BlogCardComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
