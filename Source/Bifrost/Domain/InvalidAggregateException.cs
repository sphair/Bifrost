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

namespace Bifrost.Domain
{
	/// <summary>
	/// The exception that is thrown when there is something invalid with
	/// an <see cref="AggregatedRoot">AggregatedRoot</see>
	/// </summary>
	public class InvalidAggregateException : ArgumentException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidAggregateException">InvalidAggregateException</see> class
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception</param>
		public InvalidAggregateException(string message)
			: base(message)
		{
		}
	}
}
