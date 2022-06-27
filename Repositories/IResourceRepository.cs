using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Repositories;

public interface IResourceRepository<T>
{
    public Task<ActionResult<IEnumerable<T>>> GetAll(string apikey);
    public Task<ActionResult<T>> Find(string apiKey, string identifier);
    public Task<ActionResult<T>> Store(string apiKey, T t);
    public Task<ActionResult> Update(string apiKey, string identifier, T t);
    public Task<IActionResult> Destroy(string apiKey, string identifier);
}