using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.CreatePerson
{
    public interface ICreatePersonCommand
    {
        Task<CreatePersonModel> Execute(CreatePersonModel model);
    }
}
