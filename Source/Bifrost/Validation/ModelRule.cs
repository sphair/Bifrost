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
using System.Linq.Expressions;
using System.Reflection;
using FluentValidation.Internal;
using FluentValidation;

namespace Bifrost.Validation
{
    /// <summary>
    /// Represents the rule for a model of any type
    /// </summary>
    /// <typeparam name="T">Type the rule represents</typeparam>
    public class ModelRule<T> : PropertyRule
    {
#pragma warning disable 1591 // Xml Comments
        public const string ModelRulePropertyName = "ModelRuleProperty";
        public static string ModelRuleProperty { get; set; }
#pragma warning restore 1591 // Xml Comments
        static PropertyInfo InternalProperty;
        static Func<object, object> InternalFunc = (o) => o; 
        static Expression<Func<T, object>> InternalExpression = (T o) => o; 

        static ModelRule()
        {
            InternalProperty = typeof(ModelRule<T>).GetProperty(ModelRulePropertyName);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModelRule(T)"/>
        /// </summary>
        public ModelRule()
            : base(InternalProperty, InternalFunc, InternalExpression, () => CascadeMode.StopOnFirstFailure, InternalProperty.PropertyType, typeof(T))
        {
        }
    }
}
