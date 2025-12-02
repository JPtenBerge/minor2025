using Demo.Shared.Entities;
using Demo.Shared.Dal;

namespace BlazorApp1.Dal;

public class PersonDal : IPersonDal
{
    private List<Person> s_persons =
    [
        new() { Id = 4, Name = "Cedric DAL", ExpectedScore = 5.5m },
        new() { Id = 8, Name = "Luke", ExpectedScore = 6.2m },
        new() { Id = 15, Name = "Messim", ExpectedScore = 7.9m },
    ];

    public Task<IEnumerable<Person>> GetPersonsAsync()
    {
        return Task.FromResult(s_persons.AsEnumerable());
    }

    public Task<Person> AddAsync(Person newPerson)
    {
        newPerson.Id = s_persons.Max(x => x.Id) + 1;
        s_persons.Add(newPerson);
        return Task.FromResult(newPerson);
    }
}