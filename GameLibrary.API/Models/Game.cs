#nullable disable

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Genre> Genres {get; set;}
    public Publisher Publisher { get; set; }
    public DateTime Released { get; set; }

}