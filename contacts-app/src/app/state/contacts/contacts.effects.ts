import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { of, EMPTY } from 'rxjs'; // Add `of` import
import { catchError, mergeMap, map } from 'rxjs/operators';
import * as ContactsActions from './contacts.actions';
import { ContactService } from '../../services/contacts.service';

@Injectable()
export class ContactsEffects {
  loadContacts$ = createEffect(() => this.actions$.pipe(
    ofType(ContactsActions.loadContacts),
    mergeMap(() => this.contactsService.getAll()
      .pipe(
        map(contacts => {
          return ContactsActions.loadContactsSuccess({ data: contacts });
        }),
        catchError((error: any) => of(ContactsActions.loadContactsFailure({ error })))
      ))
    )
  );

  addContact$ = createEffect(() => this.actions$.pipe(
    ofType(ContactsActions.addContact),
    mergeMap(action => this.contactsService.addContact(action.contact)
      .pipe(
        map(contact => ContactsActions.addContactSuccess({ contact })),
        catchError(error => of(ContactsActions.addContactFailure({ error })))
      ))
    )
  );
  
  constructor(
    private actions$: Actions,
    private contactsService: ContactService
  ) {}
}
