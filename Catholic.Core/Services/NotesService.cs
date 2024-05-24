using Catholic.Core.Repositories;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class NotesService : MongoRepository<Note>
{
    public NotesService(IMemoryCache cache) : base("Notes", cache)
    {
    }
    
    public async Task<Note> AddNoteAsync(Note note)
    {
        ArgumentException.ThrowIfNullOrEmpty(note.Title);
        ArgumentException.ThrowIfNullOrEmpty(note.AdditionalTitle);

        await collection.InsertOneAsync(note);
        
        UpdateCacheInBackground();
          
        return note;   
    }
    
    public async Task<Note> UpdateNoteAsync(string id, Note note)
    {
        ArgumentException.ThrowIfNullOrEmpty(note.Title);
        ArgumentException.ThrowIfNullOrEmpty(note.AdditionalTitle);
        
        note.Date = DateTime.UtcNow;
        
        await UpdateAsync(id, note);
          
        return note;   
    }
}