﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Execution;
using Microsoft.Practices.Unity;


namespace Bifrost.Unity
{
    public class Container : IContainer
    {
        readonly IUnityContainer _unityContainer;

        public Container(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T), false);
        }

        public T Get<T>(bool optional)
        {
            return (T)Get(typeof(T), optional);
        }

        public object Get(Type type)
        {
            return Get(type, false);
        }

        public object Get(Type type, bool optional)
        {
            // Todo : Figure out a way to resolve types "optionally"
            try
            {
                return _unityContainer.Resolve(type);
            }
            catch(Exception ex)
            {
                if (!optional)
                    throw ex;
                else
                    return null;
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _unityContainer.ResolveAll<T>();
        }

        public bool HasBindingFor(Type type)
        {
            return _unityContainer.IsRegistered(type);
        }

        public bool HasBindingFor<T>()
        {
            return _unityContainer.IsRegistered<T>();
        }

        public IEnumerable<object> GetAll(Type type)
        {
            return _unityContainer.ResolveAll(type);
        }

        public IEnumerable<Type> GetBoundServices()
        {
            var query = from r in _unityContainer.Registrations
                        select r.RegisteredType;
            return query;
        }

        public void Bind(Type service, Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Type type)
        {
            _unityContainer.RegisterType(typeof(T), type);
        }

        public void Bind(Type service, Type type)
        {
            _unityContainer.RegisterType(service, type);
        }

        public void Bind<T>(Type type, BindingLifecycle lifecycle)
        {
            _unityContainer.RegisterType(typeof(T), type);
        }

        public void Bind(Type service, Type type, BindingLifecycle lifecycle)
        {
            _unityContainer.RegisterType(service, type);
        }

        public void Bind<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Bind(Type service, object instance)
        {
            _unityContainer.RegisterInstance(service, instance);
        }

        LifetimeManager GetLifetimeManagerFromBindingLifecycle(BindingLifecycle lifecycle)
        {
            switch (lifecycle)
            {
                case BindingLifecycle.Singleton:
                    {
                        return new ContainerControlledLifetimeManager();
                    } break;
                case BindingLifecycle.Thread : 
                    {
                        return new PerThreadLifetimeManager();
                    } break;
                case BindingLifecycle.Transient:
                    {
                        return new TransientLifetimeManager();
                    } break;
            }


            

            return new PerResolveLifetimeManager();
        }
    }
}
