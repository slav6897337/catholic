using Catholic.Domain;

namespace Catholic.Core.Helpers;

public static class PagingExtension
{
    public static Paging<TObject> Result<TObject>(this Paging paging, List<TObject> items, int count)
        where TObject : Entity =>
        new Paging<TObject>
        {
            Count = count,
            Items = items,
            Take = paging.Take,
            Skip = paging.Skip
        };
    
    public static Paging Paging(this RequestQuery query) =>
        new()
        {
            Take = query.Take ?? 5,
            Skip = query.Skip ?? 0
        };
}