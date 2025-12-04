# Labs Blazor @ minor

Jullie gaan een mini-Instagram maken! Foto's bekijken, toevoegen, comments achterlaten bij foto's, dat hele gebeuren.

## Oefening 1: maak project aan en toon foto's

1. Maak een Blazor-project aan. Gebruik **Blazor Server** voor interactiviteit.
2. Maak een pagina die foto's toont. Styling is nog niet belangrijk.

```cs
class Photo
{
	Id;
	Title;
	Description;
	PhotoData; // base64-encoded data
}
```

`PhotoData` mag voorlopig even leeg blijven, die gaan we vullen met een uploadformulier.

## Oefening 2: foto's toevoegen

Voeg een pagina toe met daarop een formulier om nieuwe foto's toe te voegen.

## Oefening 3: foto's!!

Neem een file upload-invoerveld op in je formulier en begin daadwerkelijk foto's te tonen in je app.

## Oefening 4: dependency injection

Maak een `PhotoDal` die CRUD-acties bevat voor ophalen, toevoegen, wijzigen en verwijderen van een foto. Momenteel is de "backing store" gewoon een in-memory lijstje.

Maak alle methoden meteen alvast maar `async` voor een toekomstige andere implementatie.

## Oefening 5: styling

Kies een mooie component library uit om je app mee te stylen en style 'm!

- Navbar/AppDrawer voor header/navigatie
- Mooie buttons
- Card voor het weergeven van een foto

## Oefening 6: components

Maak een component om een foto weer te geven:

```razor
<Photo Photo="@photo" />
```

## Oefening 7: comments

Voeg een pagina toe om details van een foto te bekijken. Op deze pagina willen we ook comments laten zien bij een foto en dat men een nieuwe comment kan toevoegen. Gebruik Blazor WebAssembly om deze comments te renderen.

Zoiets in de HTML?

```razor
<PhotoDetails Photo="@photo" />
<Comments Photo="@photo" @rendermode="InteractiveWebAssembly" />
@* ^-- heeft op zijn beurt weer <Comment />-componenten *@
```

Comments mogen in een in-memory lijst, vergelijkbaar met foto's. Zorg ervoor dat de comments geprerenderd worden vanaf de serverkant middels `[PersistentState]`, de client-side DAL hoeft nog niet geimplementeerd te worden.

Implementeer alvast de UI-benodigdheden dat iedere comment ook gewijzigd en verwijderd kan worden op basis van ingestelde parameters:

```razor
<CommentDetails Comment="@comment" WithEdit="true" WithDelete="false" />
```

## Oefening 8: tijd voor een backend

Maak een backend met endpoints voor CRUD-acties van comments. Controllers/minimal API mag je zelf bepalen.

- `GetAll()`
- `Get(int id)`
- `Add()`
- `Edit()`
- `Remove()`

## Oefening 9: praten met backend

Koppel de comment get/add/edit/delete-functionaliteiten aan de in de vorige opdracht gemaakte endpoints:

- Rechtstreeks met de ingebouwde `HttpClient`
- Middels een wrapper om `HttpClient` zodat het typesafer, leesbaarder en testbaarder wordt
- Middels Flurl voor makkelijker HTTP-berichten kunnen customizen, leesbaarder en testbaarder.

## Oefening 10: testing

Gebruik bUnit om je `<Comment ... />` te testen. Test of de editmodus werkt evenals het verwijderen van een comment.

## Oefening 11: authenticatie

Implementeer authenticatie bij de mini-instagram. Bij het uploaden van een foto of plaatsen van een comment, sla op wie dat doet.

Handig: https://auth0.com/blog/auth0-authentication-blazor-web-apps/
