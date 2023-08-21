import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { addContact } from 'src/app/state/contacts/contacts.actions';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  contactForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private store: Store) {}

  ngOnInit(): void {
    this.contactForm = this.formBuilder.group({
      FirstName: [' ', Validators.required],
      Surname: ['', Validators.required],
      DOB: ['', Validators.required],
      Address: ['', Validators.required],
      PhoneNumber: ['', Validators.required],
      IBAN: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.contactForm.valid) {
      console.log('onSubmit');
      this.store.dispatch(addContact({ contact: this.contactForm.value }));
    }
  }
}
