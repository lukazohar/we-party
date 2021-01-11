import { User } from 'src/app/auth/user';

export class Party {
  id: number;
  title: string;
  description: string;
  date: Date;
  createdAt: Date;
  price: number;
  location: string;
  capacity: number;
  isPublic: boolean;
  status: string;
  userId: string;
  user: User;
}
