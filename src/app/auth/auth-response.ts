export interface AuthResponse {
  user: {
    id: number;
    name: string;
    email: string;
    accessToken: string;
  };
}
