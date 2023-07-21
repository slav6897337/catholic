namespace Catholic.Domain;

public class Paging<TObject> : Paging where TObject : Entity
{
    public int Count { get; set; }
    public List<TObject> Items { get; set; }
}

public class Paging
{
    public int Take { get; set; } = 5;
    public int Skip { get; set; }
}