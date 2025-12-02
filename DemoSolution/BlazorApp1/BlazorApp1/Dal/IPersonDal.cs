using BlazorApp1.Entities;

namespace BlazorApp1.Dal;

public interface IPersonDal
{
    Task<IEnumerable<Person>> GetPersonsAsync();
    Task<Person> AddAsync(Person newPerson);
}