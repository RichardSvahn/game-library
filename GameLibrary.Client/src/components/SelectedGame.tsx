import { FC } from 'react';
import { Game } from './types';
import './../css/selectedgame.css';

export const SelectedGame: FC<{ game: Game }> = ({ game }) => {
  return (
    <div>
      <ul>
        <h2>{game.name}</h2>
        <p>{game.publisher}</p>
        <br />
        <h4>Released:</h4>
        <p>{game.released.slice(0, 10)}</p>
        <br />
        <h4>Genres:</h4>
        <ul>
          {game.genres.map(g => (
            <li key={g}>{g}</li>
          ))}
        </ul>
      </ul>
    </div>
  );
};
