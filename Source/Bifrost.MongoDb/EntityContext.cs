#region License
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
using System.Linq;
using Bifrost.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Bifrost.MongoDb
{
    public class EntityContext<T> : IEntityContext<T>
    {
        EntityContextConnection _connection;
        MongoCollection<T> _collection;
        IBsonClassMapManager _bsonClassMapManager;
        BsonClassMap<T> _classMap;

        public EntityContext(EntityContextConnection connection, IBsonClassMapManager bsonClassMapManager)
        {
            _connection = connection;
            _bsonClassMapManager = bsonClassMapManager;

            connection.CreateCollectionIfNotExistFor<T>();
            _collection = connection.GetCollectionFor<T>();
        }



        public IQueryable<T> Entities
        {
            get { return _collection.FindAll().AsQueryable(); }
        }

        public void Attach(T entity)
        {
        }

        public void Insert(T entity)
        {
            _collection.Insert(entity);
        }

        public void Update(T entity)
        {
            Save(entity);
        }

        public void Delete(T entity)
        {
            var id = ClassMap.IdMemberMap.Getter(entity);
            var bsonId = BsonValue.Create(id);
            var query = new QueryDocument(_classMap.IdMemberMap.ElementName, bsonId);
            _collection.Remove(query);
        }

        public void Save(T entity)
        {
            _collection.Save(entity);
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
        }


        BsonClassMap<T> ClassMap
        {
            get
            {
                if (_classMap == null)
                    _classMap = _bsonClassMapManager.GetFor<T>();

                return _classMap;
            }
        }
    }
}
