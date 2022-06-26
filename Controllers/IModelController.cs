using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers;

public interface IModelController<T>
{
    public Task<ActionResult<IEnumerable<T>>> Index();
    public Task<ActionResult<T>> Show(string identifier);
    public Task<ActionResult<T>> Store(T t);
    public Task<IActionResult> Update(string identifier, T t);
    public Task<IActionResult> Destroy(string identifier);
}