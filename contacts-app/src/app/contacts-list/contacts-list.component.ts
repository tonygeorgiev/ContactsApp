import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contacts.service';
import { ContactResponse } from '../models/ContactResponse';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.css']
})
export class ContactsListComponent implements OnInit {

  public contacts: ContactResponse[] = [];

  constructor(private service: ContactService) {

  }

  ngOnInit(): void {
  this.loadContacts();console.log(this.contacts);
  }

  private loadContacts(): void {
    this.service.getAll().subscribe(
      data => this.contacts = data,
      error => console.error('Error loading contacts:', error)
      
    );
  }
}
