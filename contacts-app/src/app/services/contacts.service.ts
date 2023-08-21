import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactRequest } from 'src/app/models/ContactRequest'
import { ContactResponse } from 'src/app/models/ContactResponse'; 

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private apiUrl = 'https://localhost:7114/api/contacts';  // Replace with your actual backend API URL

  constructor(private http: HttpClient) { }

  // Fetch all contacts
  getAll(): Observable<ContactResponse[]> {
    return this.http.get<ContactResponse[]>(this.apiUrl);
  }

  // Add a new contact
  addContact(contact: ContactRequest): Observable<ContactRequest> {
    return this.http.post<ContactRequest>(this.apiUrl, contact);
  }

    
}
