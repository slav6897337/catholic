namespace Catholic.Domain;

public class HolyMass : Entity
{
    public string Description { get; set; }
    public DateTime Schedule { get; set; }
    public bool isObligation { get; set; }
}