using System.Text.Json.Serialization;
using Catholic.Domain;

namespace Catholic.SourceGenerator;

[JsonSourceGenerationOptions(
    UseStringEnumConverter = true,
    PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(BibleQuote))]
[JsonSerializable(typeof(List<BibleQuote>))]
public partial class DeserializerContext : JsonSerializerContext
{
}