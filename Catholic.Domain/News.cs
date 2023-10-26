namespace Catholic.Domain;

public class News : Entity
{
    public string? Link { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    public bool IsChurchNote { get; set; }
    public bool IsChurchNews { get; set; }
}