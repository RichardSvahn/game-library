import { FC, useState } from 'react';
import { CreateGame } from './types';
import './../css/addgame.css';

export const AddGame: FC<{ onAddGame?: () => void }> = ({ onAddGame }) => {
  const [name, setName] = useState('');
  const [genre, setGenre] = useState('');
  const [publisher, setPublisher] = useState('');
  const [released, setReleased] = useState('');

  const addGame = async () => {
    if (!name) return;
    const newGame: CreateGame = {
      name,
      genres: genre ? [genre] : [],
      publisher,
      released,
    };
    await fetch('https://localhost:7264/api/games', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newGame),
    });
    setName('');
    setGenre('');
    setPublisher('');
    setReleased('');
    onAddGame?.();
  };

  return (
    <>
      <main className='addgame'>
        <input
          className='addgame__name'
          type='text'
          value={name}
          onChange={e => setName(e.target.value)}
          placeholder='Name'
        />
        <input
          className='addgame__genre'
          type='text'
          value={genre}
          onChange={e => setGenre(e.target.value)}
          placeholder='Genre'
        />
        <input
          className='addgame__publisher'
          type='text'
          value={publisher}
          onChange={e => setPublisher(e.target.value)}
          placeholder='Publisher'
        />
        <input
          className='addgame__released'
          type='date'
          value={released}
          onChange={e => setReleased(e.target.value)}
          placeholder='Released'
        />
      </main>
      <div>
        <button className='addgame__button--submit' onClick={addGame}>
          Add Game
        </button>
      </div>
    </>
  );
};
