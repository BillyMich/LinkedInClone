export interface Comment {
  id: number;
  creatorId: number;
  creatorName: string;
  freeTxt: string;
  createdAt: string;
  updatedAt: string;
  isActive: boolean;
  status: number;
}

export interface Post {
  id: number;
  creatorId: number;
  creatorName: string;
  freeTxt: string;
  createdAt: string;
  updatedAt: string;
  isActive: boolean;
  status: number;
  comments: Comment[];
  fileDto: FileDto;
}

export interface FileDto {
  dataOfFile: any;
  fileName: string;
}
