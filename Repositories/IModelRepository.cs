using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Repositories;

public interface IModelRepository<T>
{
    public Task<ActionResult<IEnumerable<T>>> GetAll();
    public Task<ActionResult<T>> Find(string identifier);
    public Task<ActionResult<T>> Store(T t);
    public Task<ActionResult> Update(string identifier, T t);
    public Task<IActionResult> Destroy(string identifier);
}