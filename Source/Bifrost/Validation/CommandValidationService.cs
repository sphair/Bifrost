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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bifrost.Commands;
using Bifrost.Execution;

namespace Bifrost.Validation
{
    /// <summary>
    /// Represents a <see cref="ICommandValidationService">ICommandValidationService</see>
    /// </summary>
    [Singleton]
    public class CommandValidationService : ICommandValidationService
    {
        private readonly ICommandValidatorProvider _commandValidatorProvider;

        /// <summary>
        /// Initializes an instance of <see cref="CommandValidationService"/> CommandValidationService
        /// </summary>
        /// <param name="commandValidatorProvider"></param>
        public CommandValidationService(ICommandValidatorProvider commandValidatorProvider)
        {
            _commandValidatorProvider = commandValidatorProvider;
        }

#pragma warning disable 1591 // Xml Comments
        public CommandValidationResult Validate(ICommand command)
        {
            var result = new CommandValidationResult();
            var validationResults = ValidateInternal(command);
            result.ValidationResults = validationResults.Where(v => v.MemberNames.First() != ModelRule<object>.ModelRulePropertyName);
            result.CommandErrorMessages = validationResults.Where(v => v.MemberNames.First() == ModelRule<object>.ModelRulePropertyName).Select(v => v.ErrorMessage);
            return result;   
        }
#pragma warning restore 1591 // Xml Comments

        IEnumerable<ValidationResult> ValidateInternal(ICommand command)
        {
            var inputValidator = _commandValidatorProvider.GetInputValidatorFor(command);
            if (inputValidator != null)
            {
                var inputValidationErrors = inputValidator.ValidateFor(command);
                if (inputValidationErrors.Count() > 0)
                    return inputValidationErrors;
            }

            var businessValidator = _commandValidatorProvider.GetBusinessValidatorFor(command);
            if (businessValidator != null)
            {
                var businessValidationErrors = businessValidator.ValidateFor(command);
                return businessValidationErrors.Count() > 0 ? businessValidationErrors : new ValidationResult[0];
            }

            return new ValidationResult[0];
        }
    }
}