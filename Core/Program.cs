using System;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
          int id = 2;
          Data.GetFilms();
          Data.GetFilm_Collections(id);
        }
    }
}
