//advertisement.models.ts
export interface NewAdvertisement {
  title: string;
  freeTxt: string;
  status: number;
  professionalBranche: number;
  workingLocation: number;
  jobType: number;
}

export interface AdvertisementRequest {
  id: number;
  title: string;
  freeTxt: string;
  status: number;
  professionalBranche: number;
  workingLocation: number;
  jobType: number;
}

export interface AdvertisementDto {
  id: number;
  title: string;
  freeTxt: string;
  status: string;
  professionalBranche: string;
  workingLocation: string;
  jobType: string;
}
