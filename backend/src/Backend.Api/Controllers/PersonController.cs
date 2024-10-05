using Backend.Application.Database.Person.Commands.CreatePerson;
using Backend.Application.Database.Person.Commands.DeletePerson;
using Backend.Application.Database.Person.Commands.UpdatePerson;
using Backend.Application.Database.Person.Queries.GetAllPeople;
using Backend.Application.Exceptions;
using Backend.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/v1/person")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PersonController : ControllerBase
    {
        public PersonController()
        {

        }

        /*
        [HttpPost]
        public  async Task<IActionResult> test()
        {
            var number = int.Parse("hola");
            return StatusCode(StatusCodes.Status200OK, 
                ResponseApiService.Response(StatusCodes.Status200OK, "{}","Ejecución exitosa"));
        }
        */

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreatePersonModel model,
            [FromServices] ICreatePersonCommand createPersonCommand,
            [FromServices] IValidator<CreatePersonModel> validator)
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createPersonCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdatePersonModel model,
            [FromServices] IUpdatePersonCommand updatePersonCommand, 
            [FromServices] IValidator<UpdatePersonModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updatePersonCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(
            int Id,
            [FromServices] IDeletePersonCommand deletePersonCommand)
        {
            if(Id == 0) 
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deletePersonCommand.Execute(Id);
            if(!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllPeopleQuery getAllPeopleQuery)
        {
            var data = await getAllPeopleQuery.Execute();

            if(data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
