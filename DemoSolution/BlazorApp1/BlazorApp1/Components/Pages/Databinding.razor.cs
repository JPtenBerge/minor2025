using BlazorApp1.Entities;

namespace BlazorApp1.Components.Pages;

public partial class Databinding
{
    public Person NewPerson { get; set; } = new();

    public List<Person>? Persons { get; set; } =
    [
        new() { Id = 4, Name = "Cedric", ExpectedScore = 5.5m },
        new() { Id = 8, Name = "Luke", ExpectedScore = 6.2m },
        new() { Id = 15, Name = "Messim", ExpectedScore = 7.9m },
    ];

    void AddPerson()
    {
        NewPerson.Id = Persons is null ? 1 : Persons.Max(x => x.Id) + 1;
        Persons!.Add(NewPerson);
        NewPerson = new();
    }
}