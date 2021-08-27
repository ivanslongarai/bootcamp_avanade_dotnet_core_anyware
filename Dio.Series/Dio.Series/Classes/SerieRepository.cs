using Dio.Series.Interfaces;
using System.Collections.Generic;

namespace Dio.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();

        public void Delete(int id)
        {
            serieList[id - 1].setDeleted();
        }

        public Serie GetById(int id)
        {
            return serieList[id -1];
        }

        public void Insert(Serie entity)
        {
            serieList.Add(entity);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int GetNextId()
        {
            return serieList.Count + 1;
        }

        public void Update(int id, Serie entity)
        {
            serieList[id -1] = entity;
        }
    }
}
