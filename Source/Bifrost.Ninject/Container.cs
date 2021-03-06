﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Execution;
using Ninject;
using Ninject.Parameters;

namespace Bifrost.Ninject
{
    public class Container : IContainer
    {
        readonly List<Type> _boundServices;

        public Container(IKernel kernel)
        {
            Kernel = kernel;
            _boundServices = new List<Type>();
        }

        public IKernel Kernel { get; private set; }

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
            var request = Kernel.CreateRequest(type, null, new IParameter[0], optional, true);
            return Kernel.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return Kernel.GetAll<T>();
        }

        public bool HasBindingFor(Type type)
        {
            return Kernel.GetBindings(type).Count() != 0;
        }

        public bool HasBindingFor<T>()
        {
            return HasBindingFor(typeof (T));
        }

        public IEnumerable<object> GetAll(Type type)
        {
            return Kernel.GetAll(type);
        }

        public IEnumerable<Type> GetBoundServices()
        {
            return _boundServices;
        }

        public void Bind(Type type, Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type type, Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Type type)
        {
            Kernel.Bind<T>().To(type);
            _boundServices.Add(typeof(T));
        }

        public void Bind(Type service, Type type)
        {
            Kernel.Bind(service).To(type);
            _boundServices.Add(service);
        }

        public void Bind<T>(Type type, BindingLifecycle lifecycle)
        {
            Kernel.Bind<T>().To(type).WithLifecycle(lifecycle);
            _boundServices.Add(typeof(T));
        }

        public void Bind(Type service, Type type, BindingLifecycle lifecycle)
        {
            Kernel.Bind(service).To(type).WithLifecycle(lifecycle);
            _boundServices.Add(service);
        }

        public void Bind<T>(T instance)
        {
            Kernel.Bind<T>().ToConstant(instance);
            _boundServices.Add(typeof(T));
        }

        public void Bind(Type service, object instance)
        {
            Kernel.Bind(service).ToConstant(instance);
            _boundServices.Add(service);
        }
    }
}
