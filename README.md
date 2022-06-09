<h1>MoviesAPI</h1>
<p>
    MoviesAPI is an IMDB-inspired movies API that lets you 
    search for actors/actresses, movies, ratings, and casts.
</p>
<p>
    The dataset used here is taken from IMDB's public dataset
    at <a>https://datasets.imdbws.com/</a>
</p>

###Project requirements:
1. Dotnet SDK (6.0)
2. MySQL (8.0.2x)

### Project Setup
1. Recover database from `DB/moviesdb.sql` to your local database
2. Change database connection setup on `appsettings.json`
3. Run project by running `dotnet run` on the terminal
4. Navigate to https://localhost:7022/swagger/index.html/