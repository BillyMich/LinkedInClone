export class User {
  name: string;
  last_name: string;
  email: string;
  password: string;
  role: string;
  id: number;

  constructor() {
    this.name = '';
    this.last_name = '';
    this.email = '';
    this.password = '';
    this.role = '';
    this.id = 0;
  }
}
