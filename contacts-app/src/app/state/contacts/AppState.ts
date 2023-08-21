
import { ContactRequest } from 'src/app/models/ContactRequest';

export interface AppState {
    contacts: ContactsState;
  }
  
  export interface ContactsState {
    data: ContactRequest[];
    error: any; 
  }
  