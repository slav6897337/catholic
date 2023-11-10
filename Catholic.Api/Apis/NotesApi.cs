using Catholic.Api.Filters;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class NotesApi
{
    public static void MapNotesApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/notes", (NotesService notesService, [AsParameters] RequestQuery request) =>
            notesService.GetAllAsync(request.HolyMassOnly is true ? f => f.IsChurchNote : null));
        
        endpoints.MapGet("/api/notes/all", (NotesService notesService) =>
            notesService.GetAllAsync(sortBy: n => n.Date, ascending: false));
        
        endpoints.MapPost("/api/notes", (NotesService notesService, Note note) =>
            notesService.AddNoteAsync(note)).AdminAuthorization();
        
        endpoints.MapPut("/api/notes/{id}", (NotesService notesService, string id, Note note) =>
            notesService.UpdateNoteAsync(id, note)).AdminAuthorization();
        
        endpoints.MapDelete("/api/notes/{id}", (NotesService notesService, string id) =>
            notesService.DeleteAsync(id)).AdminAuthorization();
    }
}