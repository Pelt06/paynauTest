using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.DeletePerson
{
    public class DeletePersonCommand :  IDeletePersonCommand
    {
        private readonly IDatabaseService _databaseService;

        public DeletePersonCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(int Id)
        {
            var entity = await _databaseService.Person.FirstOrDefaultAsync(x => x.Id == Id);

            if (entity == null)
                return false;


            _databaseService.Person.Remove(entity);
            return await _databaseService.SaveAsync();

        }
    }
}
