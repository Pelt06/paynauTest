using AutoMapper;
using Backend.Application.Configuration;
using Backend.Application.Database.Person.Commands.CreatePerson;
using Backend.Application.Database.Person.Commands.DeletePerson;
using Backend.Application.Database.Person.Commands.UpdatePerson;
using Backend.Application.Database.Person.Queries.GetAllPeople;
using Backend.Application.Validations.Person;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            //Person
            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreatePersonCommand, CreatePersonCommand>();
            services.AddTransient<IUpdatePersonCommand, UpdatePersonCommand>();
            services.AddTransient<IDeletePersonCommand, DeletePersonCommand>();
            services.AddTransient<IGetAllPeopleQuery, GetAllPeopleQuery>();

            //Validator
            services.AddScoped<IValidator<CreatePersonModel>, CreatePersonValidator>();
            services.AddScoped<IValidator<UpdatePersonModel>, UpdatePersonValidator>();

            return services;
        }
    }
}
