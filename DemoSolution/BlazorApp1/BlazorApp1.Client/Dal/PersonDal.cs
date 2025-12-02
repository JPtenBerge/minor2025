using Demo.Shared.Dal;
using Demo.Shared.Entities;

namespace BlazorApp1.Client.Dal;

public class PersonDal : IPersonDal
{
    public Task<IEnumerable<Person>> GetPersonsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Person> AddAsync(Person newPerson)
    {
        throw new NotImplementedException();
    }
}