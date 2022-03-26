#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameContext _context;

        public GamesController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetGames(string search)
        {
            var games = _context.Game.Select(g => g);

            if(!String.IsNullOrEmpty(search))
            {
                games = games.Where(x => x.Name.Contains(search) || x.Genres.Any(n => n.Name.Contains(search)) || x.Publisher.Name.Contains(search));
            }


            return await games.Select(g => new {Id = g.Id, Name = g.Name}).ToListAsync();
            // var isListItem = true;
            // return await games.Select(g => MapGameResponse(g, isListItem)).ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGame(int id)
        {
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return MapGameResponse(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameRequest gameRequest)
        {
            var game = await _context.Game.FindAsync(id);

            if (id != game.Id)
            {
                return BadRequest();
            }

            game = UpdateGame(game, gameRequest);

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameResponse>> PostGame([FromBody]GameRequest gameRequest)
        {
            var game = MapNewGame(gameRequest);

            _context.Game.Add(game);

            await _context.SaveChangesAsync();


            return CreatedAtAction("GetGame", new { id = game.Id }, MapGameResponse(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }

        private Game MapNewGame (GameRequest gameRequest)
        {
            return new Game
            {
                Name = gameRequest.Name,
                Genres = FindGenres(gameRequest.Genres),
                Publisher = FindPublisher(gameRequest.Publisher),
                Released = gameRequest.Released
            };
        }

        private static GameResponse MapGameResponse (Game game, bool isListItem = false)
        {
            
            if (isListItem)
            {
                return new GameResponse
                {
                    Id = game.Id,
                    Name = game.Name
                };
            }

            var gameResponse = new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Genres = new List<string>(),
                Publisher = game.Publisher.Name,
                Released = game.Released
            };

            foreach (var genre in game.Genres)
            {
                gameResponse.Genres.Add(genre.Name);
            }

            return gameResponse;
        }

        private List<Genre> FindGenres (ICollection<string> genreNames)
        {
            var genres = new List<Genre>();

            foreach (var genreName in genreNames)
            {
                var genre =_context.Genre.Where(g => g.Name == genreName).FirstOrDefault();

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = genreName
                    };

                _context.Genre.Add(genre);
                }

                genres.Add(genre);
            }

            return genres;
        }

        private Publisher FindPublisher (string publisherName)
        {
            var publisher = _context.Publisher.Where(p => p.Name == publisherName).FirstOrDefault();

                if (publisher == null)
                {
                    publisher = new Publisher
                    {
                        Name = publisherName
                    };

                    _context.Publisher.Add(publisher);
                }

            return publisher;
        }

        private Game UpdateGame (Game game, GameRequest gameRequest)
        {
            game.Name = gameRequest.Name;
            game.Genres = FindGenres(gameRequest.Genres);
            game.Publisher = FindPublisher(gameRequest.Publisher);
            game.Released = gameRequest.Released;

            return game;
        }
    }
}
