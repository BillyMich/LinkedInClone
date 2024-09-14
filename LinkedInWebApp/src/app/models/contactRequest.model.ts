export class NewContactRequestDto {
  userResiverId: number;

  constructor(userResiverId: number) {
    this.userResiverId = userResiverId;
  }
}

export class ContactRequestChangeStatusDto {
  contactRequestId: number;
  statusId: number;

  constructor(contactRequestId: number, statusId: number) {
    this.contactRequestId = contactRequestId;
    this.statusId = statusId;
  }
}
