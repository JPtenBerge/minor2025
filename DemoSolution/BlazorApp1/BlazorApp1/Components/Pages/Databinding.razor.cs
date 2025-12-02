using BlazorApp1.Dal;
using BlazorApp1.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages;

public partial class Databinding
{
    [Inject] public IPersonDal PersonDal { get; set; } = null!;

    public Person NewPerson { get; set; } = new();

    public List<Person>? Persons { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Persons = (await PersonDal.GetPersonsAsync()).ToList();
    }

    async Task AddPerson()
    {
        await PersonDal.AddAsync(NewPerson);
        NewPerson = new();
        Persons = (await PersonDal.GetPersonsAsync()).ToList();
    }
}