export class User {
    name: string;
    last_name: string;
    email: string;
    password: string;
  
    constructor(name: string, last_name: string, email: string, password: string) {
        this.name = name;
        this.last_name = last_name;
        this.email = email;
        this.password = password;
    }
  }
  