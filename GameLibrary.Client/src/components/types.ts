export interface Game {
  id: number;
  name: string;
  genres: string[];
  publisher: string;
  released: string;
}

export type CreateGame = Omit<Game, 'id'>;

export type ListGame = Pick<Game, 'id' | 'name'>;
