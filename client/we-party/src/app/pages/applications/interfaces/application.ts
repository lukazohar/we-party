import { User } from '../../friends/interfaces/user';
import { Party } from '../../parties/interfaces/party';

export class Application {
  id: number;
  appliedAt?: Date;
  rate: number;
  partyId: number;
  party: Party;
  userId: string;
  user: User;
  status?: string;
}
