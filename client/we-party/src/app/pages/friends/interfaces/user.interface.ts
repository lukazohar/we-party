import { IApplication } from '../../applications/interfaces/application.interface';
import { IParty } from '../../parties/interfaces/party.interface';

export interface IUser {
  id: number;
  name: string;
  username: string;
  email: string;
  createdAt: Date;
  firstName: string;
  lastName: string;
  birthDate: Date;
  description: string;
  applications: Array<IApplication>;
  parties: Array<IParty>;
}
