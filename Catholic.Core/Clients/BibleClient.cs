using Catholic.Core.Helpers;
using Catholic.Domain;

namespace Catholic.Core.Clients;

public class BibleClient
{
    private readonly HttpClient http;


    public BibleClient(IHttpClientFactory httpClientFactory)
    {
        this.http = httpClientFactory.CreateClient("Bible");
        this.http.BaseAddress = new Uri("https://labs.bible.org");
    }

    public async Task<BibleQuote> GetBibleQuoteAsync()
    {
        var quotes = await SendAsync<BibleQuote>(HttpMethod.Get, "/api/?passage=random&type=json");
        return quotes.FirstOrDefault() ?? new ();
    }

    private async Task<List<TObject>> SendAsync<TObject>(HttpMethod method, string url) where TObject : class, new()
    {
        using var request = new HttpRequestMessage(method, url);
        using var response = await http.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();


        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return Json.Deserialize<List<TObject>>(responseString);
    }
}