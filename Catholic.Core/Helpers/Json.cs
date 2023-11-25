using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Catholic.SourceGenerator;

namespace Catholic.Core.Helpers;

/// <summary>
/// Serialize or deserialize objects to and from JSON
/// </summary>
public static class Json
{
    /// <summary>
    /// Serialize object to JSON string
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <typeparam name="TObject">Object type</typeparam>
    /// <returns>JSON representation of an object</returns>
    public static string? Serialize<TObject>(TObject? obj) where TObject : class
    {
        return obj != null
            ? JsonSerializer.Serialize(obj, GetSerializerTypeInfo<TObject>())
            : null;
    }
    
    /// <summary>
    /// Deserialize object from JSON
    /// </summary>
    /// <param name="jsonString">JSON string representation of an object</param>
    /// <typeparam name="TObject">Object type</typeparam>
    /// <returns>An object that was serialized to JSON</returns>
    public static TObject? Deserialize<TObject>(string? jsonString) where TObject : class
    {
        return jsonString != null
            ? JsonSerializer.Deserialize(jsonString, GetDeserializerTypeInfo<TObject>())
            : null;
    }
    
    private static JsonTypeInfo<TObject> GetSerializerTypeInfo<TObject>() where TObject : class =>
        typeof(TObject) switch
        {
            { } t when t == SerializerContext.Default.AdminInfo.Type =>
                SerializerContext.Default.AdminInfo as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ListAdminInfo.Type =>
                SerializerContext.Default.ListAdminInfo as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.BibleQuote.Type => 
                SerializerContext.Default.BibleQuote as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.HolyMass.Type => 
                SerializerContext.Default.HolyMass as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ListHolyMass.Type => 
                SerializerContext.Default.ListHolyMass as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.PagingHolyMass.Type => 
                SerializerContext.Default.PagingHolyMass as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.News.Type => 
                SerializerContext.Default.News as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ListNews.Type => 
                SerializerContext.Default.ListNews as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.PagingNews.Type => 
                SerializerContext.Default.PagingNews as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.Note.Type => 
                SerializerContext.Default.Note as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ListNote.Type => 
                SerializerContext.Default.ListNote as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.PagingNote.Type => 
                SerializerContext.Default.PagingNote as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.Page.Type => 
                SerializerContext.Default.Page as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ListPage.Type => 
                SerializerContext.Default.ListPage as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.PagingPage.Type => 
                SerializerContext.Default.PagingPage as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.StringArray.Type => 
                SerializerContext.Default.StringArray as JsonTypeInfo<TObject>,
            { } t when t == SerializerContext.Default.ApiStatus.Type => 
                SerializerContext.Default.ApiStatus as JsonTypeInfo<TObject>,
           
            _ => null
        } ?? throw new KeyNotFoundException($"Json source generator not found for type {typeof(TObject).Name}");

    private static JsonTypeInfo<TObject> GetDeserializerTypeInfo<TObject>() where TObject : class =>
        typeof(TObject) switch
        {
            { } t when t == DeserializerContext.Default.BibleQuote.Type =>
                DeserializerContext.Default.BibleQuote as JsonTypeInfo<TObject>,
            { } t when t == DeserializerContext.Default.ListBibleQuote.Type =>
                DeserializerContext.Default.ListBibleQuote as JsonTypeInfo<TObject>,
            
            _ => null
        } ?? throw new KeyNotFoundException($"Json source generator not found for type {typeof(TObject).Name}");
}