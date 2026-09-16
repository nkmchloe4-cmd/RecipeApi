# Recipe API

Ett ASP.NET Core WebAPI-projekt. Backend för Recipe App-kursuppgiften i webbapplikationer och mobil utveckling.


## Teknik
- ASP.NET Core WebAPI
- C#


## Komma igång
```bash
dotnet run
```

Öppna sedan http://localhost:5205/swagger i webbläsaren för att testa API:et.

## Struktur

* `Controllers/` – API-endpoints
* `Models/` – datamodeller (t.ex. Recipe)
* `Data/` – in-memory datalagring

## Status
Under utveckling. GET-endpoint för recept klar, POST/PUT/DELETE tillkommer.