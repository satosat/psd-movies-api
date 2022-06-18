using MoviesAPI.Data;

namespace MoviesAPI.Repositories;

public abstract class ModelRepository
{
    private readonly Context _context; 

    protected ModelRepository(Context context)
    {
        _context = context;
    }

    protected Context GetContext()
    {
        return _context;
    }
}