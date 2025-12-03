using Demo.Shared.Entities;

namespace Demo.Backend.Repository;

public class PersonInMemoryRepository : IPersonRepository
{
    private static List<Person> s_persons =
    [
        new() { Id = 4, Name = "Cedric backend", ExpectedScore = 5.5m },
        new() { Id = 8, Name = "Luke", ExpectedScore = 6.2m },
        new() { Id = 15, Name = "Massin", ExpectedScore = 7.9m },
    ];

    public Task<IEnumerable<Person>> GetAllAsync()
    {
        return Task.FromResult(s_persons.AsEnumerable());
    }

    public Task<Person> GetAsync(int id)
    {
        return Task.FromResult(s_persons.Single(x => x.Id == id));
    }

    public Task<Person> AddAsync(Person newPerson)
    {
        newPerson.Id = s_persons.Max(x => x.Id) + 1;
        s_persons.Add(newPerson);
        return Task.FromResult(newPerson);
    }
}