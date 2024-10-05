using AutoMapper;
using Backend.Application.Database.Person.Commands.CreatePerson;
using Backend.Application.Database.Person.Commands.UpdatePerson;
using Backend.Application.Database.Person.Queries.GetAllPeople;
using Backend.Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PersonEntity, CreatePersonModel>().ReverseMap();
            CreateMap<PersonEntity, UpdatePersonModel>().ReverseMap();
            CreateMap<PersonEntity, GetAllPeopleModel>().ReverseMap();
        }
    }
}
