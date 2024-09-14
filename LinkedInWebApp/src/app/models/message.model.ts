export class MessageDto {
  senderId: number;
  freeTxt: string;
  createdAt: Date;

  constructor(senderId: number, freeTxt: string, createdAt: Date) {
    this.senderId = senderId;
    this.freeTxt = freeTxt;
    this.createdAt = createdAt;
  }
}

export class NewMessageDto {
  receiverId: number;
  message: string;

  constructor(receiverId: number, message: string) {
    this.receiverId = receiverId;
    this.message = message;
  }
}

export class GetChatDto {
  userToChat: number;

  constructor(userToChat: number) {
    this.userToChat = userToChat;
  }
}
