using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Core
{
    class Data
    {
        private static string coonstr = ConfigurationManager.ConnectionStrings["KinoCollection"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(coonstr);
        public static List<Film> GetFilms()
        {
            return connection.Query<Film>("select * from Film").AsList();
        }
        public static List<Collection> GetCollections()
        {
            return connection.Query<Collection>("select * from Collection").AsList();
        }

        //public static List<Film_Collection> GetFilm_Collections()
        //{
        //    return connection.Query<Film_Collection>("select * from Film_Collection ").AsList();
        //}
        public static List<Film> GetFilm_Collections(int id)
        {
            return connection.Query<Film>("select f.Title from [dbo].[Film_Collection] fc" +
                                                        " join [dbo].[Film] f " +
                                                        "on fc.ID_Film = f.ID_Film " +
                                                        " join [dbo].[Collection] c " +
                                                        " on fc.ID_Collection = c.ID_Collection " +
                                                        $"where c.ID_Collection = {id}").AsList();
        }
        //public static void print(Film_Collection p)
        //{
        //    foreach (var i in p)
        //    {
        //        Console.WriteLine(p.id_film);
        //    }
        //}

        public static void AddCollection(Collection collection)
        {
            connection.Query("insert into[dbo].[Collection] " +
                            " ([ID_Collection], [Name]) " +
                            $"values ({collection.id_coll}, {collection.name})");
        }

        public static void UpdateCollection(int id, Collection collection)
        {
            connection.Query($"update [dbo].[Collection] set [Name] = '{collection.name}' where [ID_Collection] = {id}");
        }

        public static void DeleteCollection(int id)
        {
            connection.Query($"delete [dbo].[Collection] where [ID_Collection] = {id}");
        }

        public static void AddFilm(Film film)
        {
            connection.Query("insert into[dbo].[Film] " +
                            " ([ID_Film], [Title], [Country], [Duration], [Director]) " +
                            $"values ({film.ID_Film}, {film.Title}, {film.Country}, {film.Duration}, {film.Director})");
        }

        public static void UpdateFilm(int id, Film film)
        {
            connection.Query($"update [dbo].[Film] set [Title] = '{film.Title}', [Country] = '{film.Country}', [Duration] = '{film.Duration}', [Director] = '{film.Director}' where [ID_Film] = {id}");
        }

        public static void DeleteFilm(int id)
        {
            connection.Query($"delete [dbo].[Film] where [ID_Film] = {id}");
        }

        public static void AddFilm_Collection(Film_Collection film_Collection)
        {
            connection.Query("insert into[dbo].[Film_Collection] " +
                            " ([ID_FC], [ID_Film], [ID_Collection], [Date])" +
                            $"values ({film_Collection.ID_FC}, {film_Collection.ID_Film}, {film_Collection.ID_Collection}, {DateTime.Now})");
        }

        public static void DeleteFilm_Collection(int id)
        {
            connection.Query($"delete [dbo].[Film_Collection] where [ID_FC] = {id}");
        }
    }
}
