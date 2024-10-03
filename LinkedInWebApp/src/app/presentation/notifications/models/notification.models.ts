export interface ContactRequestOfUserDto {
  contactRequestsFrom: ContactRequestDto[];
  contactRequestsTo: ContactRequestDto[];
}

export interface ContactRequestDto {
  id: number;
  name: string;
  userResiverId: number;
  isActive: boolean;
  isAccepted: boolean;
}
