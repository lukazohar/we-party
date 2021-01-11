import { IUser } from 'src/app/auth/user.interface';

export interface IFriendship {
  id: number;
  createdAt: Date;
  requesterId: string;
  requester: IUser;
  receiverId: string;
  receiver: IUser;
  status: string;
}
