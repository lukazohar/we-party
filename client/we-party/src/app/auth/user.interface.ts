import { IFriendship } from '../pages/friendships/interfaces/friendship.interface';

export interface IUser {
  id: string;
  name: string;
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  friendship: IFriendship;
}
