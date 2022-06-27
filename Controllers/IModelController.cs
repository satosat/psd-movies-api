using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

public interface IModelController<T>
{
    public Task<ActionResult<IEnumerable<T>>> Index(string apiKey);
    public Task<ActionResult<T>> Show(string apiKey, string identifier);
    public Task<ActionResult<T>> Store(string apiKey, T t);
    public Task<IActionResult> Update(string apiKey, string identifier, T t);
    public Task<IActionResult> Destroy(string apiKey, string identifier);
}