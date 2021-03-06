﻿using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;

namespace Bifrost.Web.Mvc.Validation
{
    public class LessThanPropertyValidator : FluentValidationPropertyValidator
    {
        public LessThanPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator)
        {
            ShouldValidate = false;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules()) yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.GetDisplayName());
            string message = formatter.BuildMessage(Validator.ErrorMessageSource.GetString());
            var clientRule = new ModelClientValidationRule
            {
                ValidationType = "lessthan",
                ErrorMessage = message,
            };
            clientRule.ValidationParameters.Add("valuetocompare", ((LessThanValidator)Validator).ValueToCompare);

            yield return clientRule;
        }
    }
}
