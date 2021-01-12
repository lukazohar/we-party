import { Friendship } from '../pages/friendships/interfaces/friendship';

export class User {
  id: string;
  name: string;
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password: string;
  friendship: Friendship;
}
