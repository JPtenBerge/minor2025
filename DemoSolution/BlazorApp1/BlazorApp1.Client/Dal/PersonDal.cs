using Demo.Shared.Dal;
using Demo.Shared.Entities;
using Flurl.Http;

namespace BlazorApp1.Client.Dal;

public class PersonDal : IPersonDal
{
    public async Task<IEnumerable<Person>> GetPersonsAsync()
    {
        return await "https://localhost:7027/api/person".GetJsonAsync<IEnumerable<Person>>();
    }

    public async Task<Person> AddAsync(Person newPerson)
    {
        return await "https://localhost:7027/api/person".PostJsonAsync(newPerson).ReceiveJson<Person>();
    }
}