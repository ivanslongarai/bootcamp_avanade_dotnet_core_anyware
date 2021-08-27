using Dio.Series.Interfaces;
using System.Collections.Generic;

namespace Dio.Series.Classes
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> MovieList = new List<Movie>();

        public void Delete(int id)
        {
            MovieList[id - 1].setDeleted();
        }

        public Movie GetById(int id)
        {
            return MovieList[id - 1];
        }

        public void Insert(Movie entity)
        {
            MovieList.Add(entity);
        }

        public List<Movie> List()
        {
            return MovieList;
        }

        public int GetNextId()
        {
            return MovieList.Count + 1;
        }

        public void Update(int id, Movie entity)
        {
            MovieList[id - 1] = entity;
        }
    }
}
