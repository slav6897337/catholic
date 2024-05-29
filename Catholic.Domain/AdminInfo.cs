namespace Catholic.Domain;

public class AdminInfo : Entity
{
    public string Name { get; set; }
    public string Pass { get; set; }
    public string? Photo { get; set; }
    public string? Token { get; set; }
    public bool isHolymassAdmin { get; set; }
    public bool isCatholicAdmin { get; set; }
}