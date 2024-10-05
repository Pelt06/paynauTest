using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Database.Person.Queries.GetAllPeople
{
    public class GetAllPeopleQuery : IGetAllPeopleQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllPeopleQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService; 
            _mapper = mapper;

        }

        public async Task<List<GetAllPeopleModel>> Execute()
        {
            var people  = await _databaseService.Person.ToListAsync();
            return _mapper.Map<List<GetAllPeopleModel>>(people);
        }
    }
}
