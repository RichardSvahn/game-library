import { useEffect, useState } from 'react';
import { Game, ListGame } from './types';
import { AddGame } from './AddGame';
import { GameList } from './GameList';
import { SelectedGame } from './SelectedGame';
import './../css/games.css';

export const Games = () => {
  const [games, setGames] = useState<ListGame[]>([]);
  const [loading, setLoading] = useState(true);
  const [search, setSearch] = useState('');
  const [selectedGame, setSelectedGame] = useState<Game>();

  useEffect(() => {
    fetchGames();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [search]);

  const fetchGames = async () => {
    setLoading(true);
    const currentSearch = search;
    const response = await fetch(
      `https://localhost:7264/api/games?search=${search}`,
      {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      }
    );
    const result = await response.json();
    if (currentSearch !== search) return;
    setGames(result);
    setLoading(false);
  };

  const fetchGame = async ({ id }: ListGame) => {
    const response = await fetch(`https://localhost:7264/api/games/${id}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });
    const result = await response.json();
    setSelectedGame(result);
  };

  return (
    <div className='games'>
      <header>
        <AddGame onAddGame={fetchGames} />
        <div>
          <input
            className='gamelist__search'
            type='text'
            placeholder='Search'
            value={search}
            onChange={e => setSearch(e.target.value)}
          />
          {loading && <p>Loading...</p>}
        </div>
      </header>
      <main>
        <GameList games={games} onClickGame={fetchGame} />
      </main>
      <footer>{selectedGame && <SelectedGame game={selectedGame} />}</footer>
    </div>
  );
};
