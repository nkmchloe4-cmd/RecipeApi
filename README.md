# Recipe API

Backend till Recipe App. Ett ASP.NET Core WebAPI-projekt som hanterar receptdata i minnet och stödjer filuppladdning för receptbilder.

## Teknik
- ASP.NET Core WebAPI (.NET 10)
- C#
- Swagger

## Förutsättningar

Du behöver ha .NET 10 (eller senare) SDK installerat. Kontrollera med:

```bash
dotnet --version
```

## Starta backend

1. Klona detta repo till din dator.
```bash
git clone <repo-url>
```

2. Navigera till repots rotmapp:

```bash
cd RecipeApi
```

3. Återställ projektets paket:

```bash
dotnet restore
```

4. Starta API:t:

```bash
dotnet run
```

5. Terminalen visar en rad liknande `Now listening on: http://localhost:5205`. Bekräfta att adressen stämmer innan du går vidare.

6. Öppna Swagger i webbläsaren för att testa API:et direkt:
http://localhost:5205/swagger


**OBS:** Backend måste vara igång samtidigt som frontend-appen körs, annars fungerar inte receptlistan, uppladdning eller redigering. Se frontend-repots README för start av frontend.

## Struktur

* `Controllers/` – API-endpoints (GET, POST, PUT, DELETE samt filuppladdning)
* `Models/` – datamodell (Recipe)
* `Data/` – in-memory datalagring med tre exempelrecept

## Endpoints

| Metod | Endpoint | Beskrivning |
|---|---|---|
| GET | /api/recipes | Hämtar alla recept |
| POST | /api/recipes | Skapar ett nytt recept |
| PUT | /api/recipes/{id} | Uppdaterar ett befintligt recept. Returnerar 404 om id saknas |
| DELETE | /api/recipes/{id} | Tar bort ett recept. Returnerar 404 om id saknas |
| POST | /api/recipes/upload | Laddar upp en bild (max 2MB, endast jpg/png/webp). Returnerar bildens sökväg |

## Tekniska val

- **In-memory lagring** (en `List<Recipe>` i minnet) valdes istället för en riktig databas för att hålla projektet enkelt och snabbt (datan återställs vid omstart av servern).
- **CORS** är konfigurerat att endast tillåta anrop från frontend-appen på `http://localhost:5173`, av säkerhetsskäl — ingen annan adress tillåts göra anrop mot API:et.
- **Filuppladdning** begränsas till 2MB och endast bildformat (jpg, jpeg, png, webp) för att förhindra stora eller felaktiga filer. Uppladdade bilder sparas i `wwwroot/uploads` med unika, genererade filnamn för att undvika att filer med samma namn skriver över varandra.
- Samtliga endpoints returnerar tydliga HTTP-statuskoder (t.ex. 404 vid ID som inte hittas) istället för att krascha, vilket ger robust felhantering mot frontend.

## Status

Klart: samtliga CRUD-endpoints (GET, POST, PUT, DELETE) samt filuppladdning är implementerade och testade via Swagger.