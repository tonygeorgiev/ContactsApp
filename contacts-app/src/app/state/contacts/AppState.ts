
import { ContactRequest } from '../../models/ContactRequest';

export interface AppState {
    contacts: ContactsState;
  }
  
  export interface ContactsState {
    data: ContactRequest[];
    error: any; 
  }
  