# Notes

## Paradigmas der webdevelopment

**SPA - Single Page Application**

- hip
- werkt met backend samen via JSON - Web APIs   DTOs
- complexiteit
- libs/frameworks: React Angular Vue Svelte Ember Backbone Knockout Solid Qwik
  - Blazor WebAssembly: 7MB
- nadeel: duurt lang met slechte telefoon. slechte computer. slecht netwerk.
- het almachtige voordeel: hoog niveau aan interactie / feedback  - snelheid

**SSR - server-side rendering**

- die initlele eerste HTML wordt op server gerenderd
- daarna: gewoon weer een SPA
- complementair aan de SPA
  - libs: Next.js @angular/ssr Nuxt.js SvelteKit SolidStart QwikCity  ASP.NET Core
- SEO/LLMO
  - login
- hip
- complexiteit++
- op achtergrond interactie codedingetjes opsturen: hydration  streaming hydration progressive hydration

**SSG - static site generation**

- megasnelle website
- data vooraf bekend
- bol.com wehkamp amazon: `/product/2754839/muis-logitech`
- tijdens het builden-pipeline `2754839.html` genereren
- libs: Hugo 11ty Astro

**MPA - Multi Page Application**

- Blazor Static SSR
- libs/frameworks/platformen: Spring Boot  Laravel  PHP WordPress
- iedere pagina eigen HTML
- iedere pagina weer bij de server ophalen
- navigeeracties/klikjes is de server bij betrokken om HTML terug te geven
- niet hip

## Blazor verder

**nadelen**

- 7MB  "hello world"
- frontenders weinig kennis C#
- niet heel bekend / niet zo volwassen
- hacky toegang tot JS-ecosysteem
  - pre/postbuild commando  npm
  - Tailwind
  - tailwind.css
- Hot Module Reload  "live reload"
- ElementReference

**voordelen**

- single stack solution - C# front, C# back
- C#
- Microsoft
- technisch doen ze content projection erg goed
  ```razor
  <JouwComponent>
      <Template>
            
      </Template>
  </JouwComponent>
  ```

## Blazor twee uitvoeringen interactiviteit

- Blazor WebAssembly
  - `InteractiveWebAssembly`
  - al jouw code draait op de client (browser)
  - WebAssembly?
    - WASM
    - browser feature
    - code uitvoeren in browser: JavaScript, en ooit ook VBScript / Dart (Flutter)
      - nu ook WebAssembly!
    - compiler   heel .NET => browser  7MB
- Blazor Server
  - `InteractiveServer`
  - WebSocket gewrapt met SignalR
    - alles wat je doet met de UI wordt over deze websockets gecommuniceerd
    - UI dood
  - al jouw code draait op de server
  - makkelijker te combineren met K8s? veiliger?
  - Azure SignalR Service 5000 connecties?




## Validatie

Default in .NET met attributen:

- `[Required]`
- `[RegularExpression("...")]`

Is prima voor basale use cases, maar:

- nogal beperkt
- geen async validatie
- simpele modellen  `string` `int` `bool`
- unittesten

FluentValidation to the rescue!

## Dependency injection in Blazor

3 methoden om een dependency te registreren:

**Blazor Static SSR**

- `AddTransient()` - altijd een nieuwe.
- `AddScoped()` - 1 per HTTP/WebSocket/TCP-request
- `AddSingleton()` - zolang je app/server draait. 1 instance to rule them all.

**Blazor Server**

- `AddTransient()` - zelfde als Static SSR
- `AddScoped()` - per connectie / per SignalR-circuit!
- `AddSingleton()` - zelfde als Static SSR

**Blazor WebAssembly**

- `AddTransient()` - zelfde als Static SSR
- `AddScoped()` - binnen het tabblad SINGLETON
- `AddSingleton()` - zolang de app in de browser draait (refresh of sluit tabblad = weg instantie). 1 instance to rule them all.

## UI component library

Over het algemeen stappenplan om een UI component library door te voeren:

1. NuGet-package toevoegen
2. Program  DI  `.AddBlaServices()`
3. `<link>` `.css`  `.js` importeren  fonts
4. App.razor/Host.razor  globale componenten  `<Theme />`, `<Modal />`
5. ready to go: `<MudButton />`
