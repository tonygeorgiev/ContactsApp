import { createReducer, on } from '@ngrx/store';
import * as ContactsActions from './contacts.actions';
import { ContactsState } from './AppState';


export const initialState: ContactsState = {
  data: [],
  error: null
};

export const contactsReducer = createReducer(
  initialState,
  on(ContactsActions.loadContactsSuccess, (state, { data }) => ({ ...state, data: [...data] })),
  on(ContactsActions.loadContactsFailure, (state, { error }) => ({ ...state, error })),
  on(ContactsActions.addContactSuccess, (state, { contact }) => ({ ...state, data: [...state.data, contact] })),
  on(ContactsActions.addContactFailure, (state, { error }) => ({ ...state, error }))
);
