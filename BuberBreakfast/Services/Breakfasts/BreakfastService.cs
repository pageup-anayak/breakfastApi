using BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Models;
using BuberBreakfast.ServicesErrors;
using ErrorOr;
using BuberBreakfast.Contracts.Breakfast;

public class BreakfastService : IBreakfastService
{
  // Storing in memory for now
  private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
  public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
  {
    _breakfasts.Add(breakfast.Id, breakfast);
    return Result.Created;
  }
  public ErrorOr<Breakfast> GetBreakfast(Guid id)
  {
    if (_breakfasts.TryGetValue(id, out var breakfast))
    {
      return breakfast;
    }
    return Errors.Breakfast.NotFound;

  }
  public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
  {
    var IsNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
    _breakfasts.Remove(breakfast.Id);
    _breakfasts.Add(breakfast.Id, breakfast);
    // return Result.Updated;
    return new UpsertedBreakfast(IsNewlyCreated);
  }
  public ErrorOr<Deleted> DeleteBreakfast(Guid id)
  {
    _breakfasts.Remove(id);
    return Result.Deleted;
  }
}
