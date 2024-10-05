using Backend.Application.Database.Person.Commands.CreatePerson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Validations.Person
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonModel>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.firstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.lastName).NotNull().NotEmpty().MaximumLength(50); 
            RuleFor(x => x.userName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.birthday).NotNull();
            RuleFor(x => x.email).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.phoneNumber).NotNull().NotEmpty().MaximumLength(15);
        }
    }
}
