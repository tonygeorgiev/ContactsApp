import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsListComponent } from './contacts-list/contacts-list.component';
import { AddContactComponent } from './add-contact/add-contact.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // default route
  { path: 'home', component: ContactsListComponent },
  { path: 'add', component: AddContactComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
