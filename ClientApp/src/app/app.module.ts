import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BlogListComponent } from './blog-list/blog-list.component';
import { BlogCardComponent } from './blog-card/blog-card.component';
import { BlogMenuComponent } from './blog-menu/blog-menu.component';
import { BlogLoginComponent } from './blog-login/blog-login.component';
import { BlogHomeComponent } from './blog-home/blog-home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { BlogPostComponent } from './blog-post/blog-post.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    BlogListComponent,
    BlogCardComponent,
    BlogMenuComponent,
    BlogLoginComponent,
    BlogHomeComponent,
    PageNotFoundComponent,
    BlogPostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
