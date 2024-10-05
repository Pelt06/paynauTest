

using Backend.Api;
using Backend.Application;
using Backend.Application.Database;
using Backend.Application.Database.Person.Commands.CreatePerson;
using Backend.Application.Database.Person.Commands.DeletePerson;
using Backend.Application.Database.Person.Commands.UpdatePerson;
using Backend.Application.Database.Person.Queries.GetAllPeople;
using Backend.Common;
using Backend.External;
using Backend.Persistence;
using Backend.Persistence.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);


builder.Services.AddControllers();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseCors("AllowFrontendLocalhost");
app.MapControllers();
app.Run();




/*
app.MapPost("/testServiceCreate", async (ICreatePersonCommand service) => 
{
    var person = new CreatePersonModel
    {
        firstName = "Pablo",
        lastName = "Lopez",
        userName = "Pelt06",
        birthday = DateTime.Now,
        email = "peltzjr11@gmail.com",
        phoneNumber = "1234567890",
    };

    return await service.Execute(person);
});

app.MapPost("/testServiceUpdate", async (IUpdatePersonCommand service) =>
{
    var person = new UpdatePersonModel
    {
        Id= 1,
        firstName = "Enrique",
        lastName = "Lopez",
        userName = "Pelt0611",
        birthday = DateTime.Now,
        email = "peltzjr11@outlook.com",
        phoneNumber = "11111111",
    };

    return await service.Execute(person);
});

app.MapPost("/testServiceDelete", async (IDeletePersonCommand service) =>
{

    return await service.Execute(1);
});

app.MapGet("/testServiceGet", async (IGetAllPeopleQuery service) =>
{

    return await service.Execute();
});
*/
