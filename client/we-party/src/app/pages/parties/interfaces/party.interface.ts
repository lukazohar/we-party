import { IUser } from 'src/app/auth/user.interface';

export interface IParty {
  id: number;
  title: string;
  description: string;
  date: Date;
  createdAt: Date;
  price: number;
  location: string;
  capacity: number;
  isPublic: boolean;
  userId: string;
  status: string;
  user: IUser;
}
