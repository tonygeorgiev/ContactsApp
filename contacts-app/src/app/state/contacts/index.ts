// index.ts
import { ActionReducerMap } from '@ngrx/store';
import { contactsReducer } from './contacts.reducer';
import { ContactsState } from './AppState';
// import other reducers if you have them

export interface AppState {
   contacts: ContactsState;
   // other state slices, e.g., users: UserState
}

export const reducers: ActionReducerMap<AppState> = {
   contacts: contactsReducer,
   // other reducers, e.g., users: usersReducer
};
