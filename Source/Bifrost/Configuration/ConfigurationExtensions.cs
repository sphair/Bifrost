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
using Bifrost.Events;
using Bifrost.Execution;
using Microsoft.Practices.ServiceLocation;
using Bifrost.Sagas;

namespace Bifrost.Configuration
{
	/// <summary>
	/// Provides Configuration extensions
	/// </summary>
    public static partial class ConfigurationExtensions
    {
		/// <summary>
		/// Sets a specific application for Bifrost
		/// </summary>
		/// <param name="configuration"><see cref="IConfigure"/> instance to configure</param>
		/// <param name="application"><see cref="IApplication"/> instance to set</param>
		/// <returns>Chained <see cref="IConfigure"/> instance</returns>
        public static IConfigure SpecificApplication(this IConfigure configuration, IApplication application)
        {
            configuration.ApplicationManager.Set(application);
            return configuration;
        }


        /// <summary>
        /// Configures events to not be persisted
        /// </summary>
        /// <param name="configuration"><see cref="IEventsConfiguration"/> instance to configure</param>
        /// <returns>Chained <see cref="IConfigure"/> instance</returns>
        public static IConfigure WithoutEventStore(this IEventsConfiguration configuration)
        {
            configuration.EventStoreType = typeof(NullEventStore);
            return Configure.Instance;
        }


        /// <summary>
        /// Configure sagas to not be persisted
        /// </summary>
        /// <param name="configuration"><see cref="ISagasConfiguration"/> instance to configure</param>
        /// <returns>Chained <see cref="IConfigure"/> instance</returns>
        public static IConfigure WithoutLibrarian(this ISagasConfiguration configuration)
        {
            configuration.LibrarianType = typeof(NullSagaLibrarian);
            return Configure.Instance;
        }
    }
}
