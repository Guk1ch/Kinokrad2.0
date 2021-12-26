using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class CollectionStorage
    {
        public static List<Collection> collections { get; set; } = Data.GetCollections();

        public static void AddCollection(Collection collection)
        {
            Data.AddCollection(collection);
            collections = Data.GetCollections(); 
        }
    }
}
