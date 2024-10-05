using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.DeletePerson
{
    public interface IDeletePersonCommand
    {
        Task<bool> Execute(int Id);
    }
}
