export class UpdateUserSettingsDto {
  email?: string;
  oldPassword?: string;
  password?: string;

  constructor(email?: string, oldPassword?: string, password?: string) {
    this.email = email;
    this.oldPassword = oldPassword;
    this.password = password;
  }
}
