#nullable disable

public class GameRequest
{
    public string Name { get; set; }
    public ICollection<string> Genres {get; set;}
    public string Publisher { get; set; }
    public DateTime Released { get; set; }

}