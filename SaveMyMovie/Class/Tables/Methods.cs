using System.Collections.Generic;
using System.Linq;

namespace SaveMyMovie.Class.Tables
{
    public class Methods
    {
        /// <summary>
        /// Inserts the movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        public void InsertMovie(MovieTable movie)
        {
            DataBase.Connection.MovieTables.InsertOnSubmit(movie);
            DataBase.Connection.SubmitChanges();
        }

        /// <summary>
        /// Gets the movies.
        /// </summary>
        /// <returns></returns>
        public List<MovieTable> GetMovies()
        {
            return DataBase.Connection.MovieTables.ToList();
        }

        /// <summary>
        /// Gets the movie.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public MovieTable GetMovie(int id)
        {
            return DataBase.Connection.MovieTables.FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Deletes the movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        public void DeleteMovie(MovieTable movie)
        {
            DataBase.Connection.MovieTables.DeleteOnSubmit(movie);
            DataBase.Connection.SubmitChanges();
        }

        /// <summary>
        /// Updates the movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        public void UpdateMovie(MovieTable movie)
        {
            var updatedMovie = DataBase.Connection.MovieTables.FirstOrDefault(p => p.ID == movie.ID);
            updatedMovie.WantSee = movie.WantSee;
            updatedMovie.Wish = movie.Wish;
            DataBase.Connection.SubmitChanges();
        }

    }
}
