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

using System;

namespace Bifrost.Execution
{
	/// <summary>
	/// Defines a base abstract class for Binding conventions for any <see cref="IContainer"/>
	/// </summary>
	public abstract class BaseConvention : IBindingConvention
	{
		/// <summary>
		/// Gets or sets the <see cref="BindingLifecycle">ActivationScope</see> that will be used as default
		/// </summary>
		public BindingLifecycle DefaultScope { get; set; }

#pragma warning disable 1591 // Xml Comments
		public abstract bool CanResolve(IContainer container, Type service);
		public abstract void Resolve(IContainer container, Type service);
#pragma warning restore 1591 // Xml Comments


		/// <summary>
		/// Handle scope for a target type
		/// </summary>
		/// <param name="targetType">Target type</param>
		/// <returns><see cref="BindingLifecycle"/> for the target type</returns>
		/// <remarks>
		/// If the target is marked with the <see cref="SingletonAttribute">Singleton</see> attribute, it will use
		/// that scope instead, as that is a explicit implementation information.
		/// 
		/// Otherwise it will use the DefaultScope
		/// </remarks>
        protected BindingLifecycle GetScopeForTarget(Type targetType)
		{
		    var attributes = targetType.GetCustomAttributes(typeof(SingletonAttribute), false);
		    return attributes.Length == 1 ? BindingLifecycle.Singleton : DefaultScope;
		}
	}
}