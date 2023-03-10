import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BlogHomeComponent } from './blog-home/blog-home.component';
import { BlogLoginComponent } from './blog-login/blog-login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: BlogHomeComponent },
  { path: 'login', component: BlogLoginComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
