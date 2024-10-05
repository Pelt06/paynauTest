using AutoMapper;
using Backend.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreatePersonCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreatePersonModel> Execute(CreatePersonModel model)
        {
            var person = _mapper.Map<PersonEntity>(model);
            await _databaseService.Person.AddAsync(person);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
