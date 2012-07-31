﻿#region License
//
// Copyright (c) 2008-2012, DoLittle Studios AS and Komplett ASA
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// With one exception :
//   Commercial libraries that is based partly or fully on Bifrost and is sold commercially,
//   must obtain a commercial license.
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at
//
//   http://bifrost.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using MongoDB.Driver;

namespace Bifrost.MongoDb
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoServer Server { get; private set; }
        public MongoDatabase Database { get; private set; }

        public MongoDbContext(EntityContextConnection connection)
        {
            Server = MongoServer.Create(connection.ConnectionString);
            Database = Server.GetDatabase(connection.DatabaseName);
        }

        public void CreateCollectionIfNotExistFor<T>()
        {
            var collectionName = GetCollectionNameFor<T>();
            if (!Database.CollectionExists(collectionName))
                Database.CreateCollection(collectionName);
        }

        public MongoCollection<T> GetCollectionFor<T>()
        {
            var collectionName = GetCollectionNameFor<T>();
            return Database.GetCollection<T>(collectionName);
        }

        static string GetCollectionNameFor<T>()
        {
            var collectionName = typeof(T).Name;
            return collectionName;
        }
    }
}
