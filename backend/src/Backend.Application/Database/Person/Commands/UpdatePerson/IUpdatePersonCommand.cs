using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.UpdatePerson
{
    public interface IUpdatePersonCommand
    {
        Task<UpdatePersonModel> Execute(UpdatePersonModel model);
    }
}
