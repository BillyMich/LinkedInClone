export interface CreateUserEducationDto {
  degreeTitle: string;
  description: string;
  startDate: string;
  endDate: string;
  isPublic: boolean;
  educationTypeId: number;
}
