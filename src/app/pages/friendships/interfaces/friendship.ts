import { User } from 'src/app/auth/user';

export class Friendship {
  id: number;
  createdAt: Date;
  requesterId: string;
  requester: User;
  receiverId: string;
  receiver: User;
  status: string;
}
