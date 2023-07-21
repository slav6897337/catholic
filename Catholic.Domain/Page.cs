namespace Catholic.Domain;

public class Page : Entity
{
    public string? UrlSegment { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public List<string>? Images { get; set; }
}