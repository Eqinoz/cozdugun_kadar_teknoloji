using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ParentValidator:AbstractValidator<Parent>
    {
        public ParentValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(3).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(3).NotEmpty();
            RuleFor(p => p.Email).EmailAddress().NotEmpty();
        }
    }
}
