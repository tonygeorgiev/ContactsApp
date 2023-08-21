export class ContactRequest {
    constructor(
      public firstName: string,
      public surname: string,
      public dob: Date,
      public address: string,
      public phoneNumber: string,
      public iban: string
    ) {}
  }