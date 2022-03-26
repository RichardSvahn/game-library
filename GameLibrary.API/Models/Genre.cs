#nullable disable

public class Genre
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public ICollection<Game> Games { get; set; }
}