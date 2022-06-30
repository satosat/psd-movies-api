<h1>MoviesAPI</h1>
<p>
    MoviesAPI is an IMDB-inspired movies API that lets you 
    search for actors/actresses, movies, ratings, and casts.
</p>
<p>
    The dataset used here is taken from IMDB's public dataset
    at <a>https://datasets.imdbws.com/</a>
</p>

### Project requirements:
1. Dotnet SDK (6.0)
2. MySQL (8.0.2x)

### Project Setup
1. Recover database from `DB/moviesdb.sql` to your local database
2. Change database connection setup on `appsettings.json`
3. (Optional) Adjust MySQL version in `Program.cs` file, line 17
4. Run project by running `dotnet run` on the terminal
5. Navigate to https://localhost:7022/swagger/index.html/

### Models
1. `Title`: refers to the `titles` table
   1. Tconst: acts as Primary Key, refering to the ID of the title (movie)
   2. PrimaryTitle: international title for the movie
   3. OriginalTitle: the movie's original title
   4. StartYear: movie's release year
2. `Name`: refers to the `names` table
   1. Nconst acts as a Primary Key, refering to the ID of the person
   2. PrimaryName: name of the person
   3. BirthYear: the person's birth year
   4. DeathYear: the person's death year, `null` if not applicable
3. `Rating`: refers to the `ratings` table
   1. Tconst: acts as Foreign Key to the corresponding Title Tconst
   2. AverageRating: the average rating of the title
4. `Cast`: refers to the table structure of `GetCastsByTconst` procedure
   1. Nconst: the cast's ID
   2. PrimaryName: name of the cast

### Resources Endpoints
##### Default
1. GET `/{Model}`: returns all the resource on the database
3. GET `/{Model}/{ID}`: show a resource, specified by the resource's ID (nconst/tconst)
##### Work
1. GET `/Work/Movies/{nconst}`: return all the titles that's been done by the specified person 
2. GET `/Work/Casts/{tconst}`: return all the casts(names) from the specified title

#### NB: Account API isn't a part of resource 