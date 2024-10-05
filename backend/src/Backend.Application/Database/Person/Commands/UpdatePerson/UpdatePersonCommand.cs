using AutoMapper;
using Backend.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdatePersonCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<UpdatePersonModel> Execute(UpdatePersonModel model)
        {
            var person = _mapper.Map<PersonEntity>(model);
            _databaseService.Person.Update(person);
            await _databaseService.SaveAsync();
            return model;
        }
    }

}
