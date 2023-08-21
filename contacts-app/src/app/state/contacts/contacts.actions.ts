import { createAction, props } from '@ngrx/store';
import { ContactRequest } from 'src/app/models/ContactRequest';

export const loadContacts = createAction('[Contacts] Load Contacts');
export const loadContactsSuccess = createAction('[Contacts] Load Contacts Success', props<{ data: ContactRequest[] }>());
export const loadContactsFailure = createAction('[Contacts] Load Contacts Failure', props<{ error: any }>());

// Actions for adding a contact
export const addContact = createAction('[Contacts] Add Contact', props<{ contact: ContactRequest }>());
export const addContactSuccess = createAction('[Contacts] Add Contact Success', props<{ contact: ContactRequest }>());
export const addContactFailure = createAction('[Contacts] Add Contact Failure', props<{ error: any }>());
