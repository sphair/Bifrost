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
using System.Linq;
using Bifrost.Entities;
using MongoDB.Driver;

namespace Bifrost.MongoDB
{
    public class EntityContext<T> : IEntityContext<T>
    {
        EntityContextConnection _connection;
        string _collectionName;
        MongoCollection<T> _collection;

        public EntityContext(EntityContextConnection connection)
        {
            _connection = connection;
            _collectionName = typeof(T).Name;
            if( !_connection.Database.CollectionExists(_collectionName) )
                _connection.Database.CreateCollection(_collectionName);

            _collection = _connection.Database.GetCollection<T>(_collectionName);
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
    }
}
