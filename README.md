WorldCities Web API
Detta projekt tillhandahåller ett Web API för att hantera information om städer världen över. API:et möjliggör CRUD-operationer (Create, Read, Update, Delete) för städer lagrade i en databas.

Databasstruktur
API:et interagerar med en databastabell vid namn WorldCities. Denna tabell har följande kolumner:

CityId (Int): Primärnyckel, unikt ID för varje stad.

City (String): Namnet på staden.

Country (String): Landet där staden ligger.

Population (Int): Befolkningen i staden.

API-funktionalitet
Följande funktioner kan utföras via API:et:

Hämta alla städer: Visar en lista över alla städer, sorterade så att städer med flest invånare visas först.

Skapa en stad: Lägger till en ny stad i databasen.

Hämta en specifik stad: Hämtar information om en stad baserat på dess CityId.

Uppdatera en stad: Ändrar befintlig information för en stad.

Ta bort en stad: Raderar en stad från databasen.

Komma igång

Nödvändiga Nugetpackages för installation:
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore


