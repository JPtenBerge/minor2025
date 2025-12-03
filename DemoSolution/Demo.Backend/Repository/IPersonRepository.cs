using Demo.Shared.Entities;

namespace Demo.Backend.Repository;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> GetAsync(int id);
    Task<Person> AddAsync(Person newPerson);
}