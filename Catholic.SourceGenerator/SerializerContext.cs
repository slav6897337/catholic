using System.Text.Json.Serialization;
using Catholic.Domain;

namespace Catholic.SourceGenerator;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    UseStringEnumConverter = true)]
[JsonSerializable(typeof(AdminInfo))]
[JsonSerializable(typeof(List<AdminInfo>))]
[JsonSerializable(typeof(BibleQuote))]
[JsonSerializable(typeof(HolyMass))]
[JsonSerializable(typeof(List<HolyMass>))]
[JsonSerializable(typeof(Paging<HolyMass>))]
[JsonSerializable(typeof(News))]
[JsonSerializable(typeof(List<News>))]
[JsonSerializable(typeof(Paging<News>))]
[JsonSerializable(typeof(Note))]
[JsonSerializable(typeof(List<Note>))]
[JsonSerializable(typeof(Paging<Note>))]
[JsonSerializable(typeof(Page))]
[JsonSerializable(typeof(List<Page>))]
[JsonSerializable(typeof(Paging<Page>))]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(ApiStatus))]
public partial class SerializerContext : JsonSerializerContext
{
}