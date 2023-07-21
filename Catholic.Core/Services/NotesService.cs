using Catholic.Core.Repositories;
using Catholic.Domain;

namespace Catholic.Core.Services;

public class NotesService : MongoRepository<Note>
{
    public NotesService() : base("Notes")
    {
    }
    
    public async Task<Note> AddNoteAsync(Note note)
    {
        ArgumentException.ThrowIfNullOrEmpty(note.Title);
        ArgumentException.ThrowIfNullOrEmpty(note.AdditionalTitle);

        await collection.InsertOneAsync(note);
          
        return note;   
    }
    
    public async Task<Note> UpdateNoteAsync(string id, Note note)
    {
        ArgumentException.ThrowIfNullOrEmpty(note.Title);
        ArgumentException.ThrowIfNullOrEmpty(note.AdditionalTitle);
        
        await UpdateAsync(id, note);
          
        return note;   
    }
}