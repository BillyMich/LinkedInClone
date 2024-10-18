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

export interface PostNotificationDto {
  commentNotifications: CommentNotificationDto[];
  reactionsNotifications: PostReactionDto[];
}

export interface CommentNotificationDto {
  postId: number;
  userId: number;
  userName: string;
  commentTxt: string;
  createdAt: string;
}

export interface PostReactionDto {
  postId: number;
  userId: number;
  userName: string;
  createdAt: string;
}
