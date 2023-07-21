namespace Catholic.Domain;

public class Note : Entity
{
    public string? Title { get; set; }
    public string? AdditionalTitle { get; set; }
    public string? Info { get; set; }
    public string? RepeatableDate { get; set; }
    public bool IsChurchNote { get; set; }
}