import { IUser } from 'src/app/auth/user.interface';
import { IParty } from '../../parties/interfaces/party.interface';

export interface IApplication {
  id?: number;
  appliedAt?: Date;
  rate?: number;
  partyId: number;
  party?: IParty;
  userId?: string;
  user?: IUser;
  status?: string;
}
