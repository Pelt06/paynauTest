using Backend.Application.Database.Person.Commands.UpdatePerson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Validations.Person
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonModel>
    {
        public UpdatePersonValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.firstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.userName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.birthday).NotNull();
            RuleFor(x => x.email).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().MaximumLength(15);
        }
    }
}
