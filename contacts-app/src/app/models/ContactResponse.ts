export class ContactResponse {
    constructor(
      public id: number,
      public firstName: string,
      public surname: string,
      public dob: Date,
      public address: string,
      public phoneNumber: string,
      public iban: string
    ) {}
  }
  
  
  
  