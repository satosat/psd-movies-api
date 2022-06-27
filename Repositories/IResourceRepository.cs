using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Repositories;

public interface IResourceRepository<T>
{
    public Task<ActionResult<IEnumerable<T>>> GetAll(string apikey);
    public Task<ActionResult<T>> Find(string apiKey, string identifier);
}