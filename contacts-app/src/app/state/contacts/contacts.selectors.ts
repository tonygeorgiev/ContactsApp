import { createSelector } from '@ngrx/store';
import { AppState } from 'src/app/state/contacts/AppState';  
import { ContactsState } from './AppState';

export const selectContactsState = (state: AppState) => state.contacts;

export const selectAllContacts = createSelector(
  selectContactsState,
  contactsState => contactsState.data
);
export const selectLastAddedContact = createSelector(
    selectAllContacts,
    contacts => contacts[contacts.length - 1]
  );