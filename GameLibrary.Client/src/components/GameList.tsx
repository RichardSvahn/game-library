import { FC } from 'react';
import { ListGame } from './types';
import './../css/gamelist.css';

export const GameList: FC<{
  games: ListGame[];
  onClickGame?: (game: ListGame) => void;
}> = ({ games, onClickGame }) => (
  <div className='gamelist'>
    <header className='gamelist__header'>My Games:</header>
    <ul>
      {games.map(g => (
        <li key={g.id} onClick={() => onClickGame?.(g)}>
          <p className='gamelist__game'>{g.name}</p>
        </li>
      ))}
    </ul>
  </div>
);
