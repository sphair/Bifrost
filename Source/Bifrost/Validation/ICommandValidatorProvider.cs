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
using Bifrost.Commands;

namespace Bifrost.Validation
{
    /// <summary>
    /// Defines a provider that returns command-specific input and business rule validators
    /// </summary>
    public interface ICommandValidatorProvider
    {
        /// <summary>
        /// Retrieves an input validator specific to the command
        /// </summary>
        /// <param name="command">Command to be validates</param>
        /// <returns>Returns specific validator or a NullValidator if no validator is available</returns>
        ICanValidate GetInputValidatorFor(ICommand command);

        /// <summary>
        /// Retrieves an business-rule validator specific to the command
        /// </summary>
        /// <param name="command">Command to be validates</param>
        /// <returns>Returns specific validator or a NullValidator if no validator is available</returns>
        ICanValidate GetBusinessValidatorFor(ICommand command);

        /// <summary>
        /// Retrieves an input validator specific to the command type
        /// </summary>
        /// <param name="type">Type of the Command to be validates</param>
        /// <returns>Returns specific validator or a NullValidator if no validator is available</returns>
        ICanValidate GetInputValidatorFor(Type type);

        /// <summary>
        /// Retrieves an business-rule validator specific to the command type
        /// </summary>
        /// <param name="type">Type of the Command to be validates</param>
        /// <returns>Returns specific validator or a NullValidator if no validator is available</returns>
        ICanValidate GetBusinessValidatorFor(Type type);
    }
}