using MoviesAPI.Data;

namespace MoviesAPI.Repositories;

public class Repository
{
    private readonly Context _context;

    protected Repository(Context context)
    {
        _context = context;
    }

    protected Context GetContext()
    {
        return _context;
    }
}