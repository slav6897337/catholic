namespace Catholic.Domain;

public class BibleQuote
{
    public string Bookname { get; set; }
    public string Chapter { get; set; }
    public string Verse { get; set; }
    public string Text { get; set; }
    public DateTime Time { get; set; }
}