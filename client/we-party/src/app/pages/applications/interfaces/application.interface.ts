import { IUser } from '../../friends/interfaces/user.interface';
import { IParty } from '../../parties/interfaces/party.interface';

export interface IApplication {
  id: number;
  appliedAt: Date;
  rate: number;
  partyId: number;
  party: IParty;
  userId: string;
  applicationUser: IUser;
  status: string;
}
