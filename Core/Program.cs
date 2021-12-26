using System;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
          int id = 1;
          Data.GetFilms();
          var i = Data.GetFilm_Collections(id);
            foreach (var a in i)
            {
                Console.WriteLine(a.Title);
            }
            Console.WriteLine("ad");
        }
    }
}
