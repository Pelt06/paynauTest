using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Queries.GetAllPeople
{
    public interface IGetAllPeopleQuery
    {
        Task<List<GetAllPeopleModel>> Execute();
    }
}
