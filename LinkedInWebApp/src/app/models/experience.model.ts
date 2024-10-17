export interface CreateUserExperience {
  id?: number;
  userId?: number;
  title: string;
  freeTxt: string;
  isPublic: boolean;
  isActive?: boolean;
  createdAt?: string;
  updatedAt?: string;
  startedAt: string;
  endedAt?: string;
}
