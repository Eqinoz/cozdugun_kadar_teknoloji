using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ChildValidator:AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(c=>c.FirstName).MinimumLength(3).NotEmpty();
            RuleFor(c => c.ParentId).NotEmpty();
        }
    }
}
