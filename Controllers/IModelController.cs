using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

public interface IModelController<T>
{
    public Task<ActionResult<IEnumerable<T>>> Index(string apiKey);
    public Task<ActionResult<T>> Show(string apiKey, string identifier);
}