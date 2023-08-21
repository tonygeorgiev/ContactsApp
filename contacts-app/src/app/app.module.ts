import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// NgRx related imports
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers } from './state/contacts/index' // assuming your combined reducers are in store/index.ts
import { ContactsEffects } from './state/contacts/contacts.effects'
import { contactsReducer } from './state/contacts/contacts.reducer';

// PrimeNG related imports
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AddContactComponent } from './add-contact/add-contact.component';
import { ContactsListComponent } from './contacts-list/contacts-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddContactComponent,
    ContactsListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    // PrimeNG components
    CalendarModule,
    InputTextModule,
    ButtonModule,

    // NgRx setup
    StoreModule.forRoot(reducers),
    StoreModule.forRoot({ contacts: contactsReducer }),
    EffectsModule.forRoot([ContactsEffects]),

    // ... any other modules you might be using
  ],
  providers: [
    // ... any services you want to register
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
