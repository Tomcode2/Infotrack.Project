using FluentValidation;
using Infotrack.FrequencyFinder.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Api.Validators
{
    /// <summary>
    /// Validator for the SaveSearchResource class.
    /// </summary>
    public class SaveSearchResourceValidator : AbstractValidator<SaveSearchResource>
    {
        public SaveSearchResourceValidator()
        {
            RuleFor(a => a.SearchQuery)
                .NotEmpty()
                .WithMessage("Please provide a keyword to search")
                .MaximumLength(100);
        }
    }
}
