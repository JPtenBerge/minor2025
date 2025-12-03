using Demo.Backend.Repository;
using Demo.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Demo.Backend.Endpoints;

public static class PersonEndpoints
{
    public static void MapPersonEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/person").WithTags("Person");
        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", Get);
        group.MapPost("/", Post);
    }

    public static async Task<IEnumerable<Person>> GetAll(IPersonRepository repository)
    {
        return await repository.GetAllAsync();
    }

    public static async Task<Results<NotFound<string>, Ok<Person>>> Get(IPersonRepository repository, int id)
    {
        try
        {
            var person = await repository.GetAsync(id);
            return TypedResults.Ok(person);
        }
        catch (InvalidOperationException)
        {
            return TypedResults.NotFound($"Person with ID {id} could not be found");
        }
    }
    
    // meestal niet zomaar Entities terug aan geven. ==> DTOs
    
    public static async Task<Person> Post(IPersonRepository repository, Person newPerson)
    {
        // TODO: perform validation

        var updatedPerson = await repository.AddAsync(newPerson);
        return updatedPerson;
    }
}