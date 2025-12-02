using Demo.Shared.Entities;

namespace Demo.Shared.Dal;

public interface IPersonDal
{
    Task<IEnumerable<Person>> GetPersonsAsync();
    Task<Person> AddAsync(Person newPerson);
}