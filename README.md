# Mjos.Clean

Clean Architecture with MediatR

```Shell
git clone https://github.com/manueljoaosantos/Mjos.Clean.git
dotnet new sln
dotnet new classlib -o Mjos.Clean.Domain
dotnet sln add .\Mjos.Clean.Domain\

git flow init

git flow feature start Domain
...
git flow feature finish Domain

```

```Shell
git flow feature start Shared

dotnet new classlib -o Mjos.Clean.Shared
dotnet sln add .\Mjos.Clean.Shared\

...

git flow feature finish Shared

```

```Shell
git flow feature start Application

dotnet new classlib -o Mjos.Clean.Application
dotnet sln add .\Mjos.Clean.Application\

...

git flow feature finish Application

```

```
PS C:\Temp\Mjos.Clean> dotnet ef migrations add IdentityInitial -p Mjos.Clean.Persistence -s Mjos.Clean.Api -c ApplicationDbContext -o Data/Migrations
PS C:\Temp\Mjos.Clean\Mjos.Clean.Api> dotnet ef database update -c ApplicationDbContext
```

dotnet new xunit -o Mjos.Clean.Tests

```
C:\Program Files\OpenSSL-Win64\bin\openssl.exe req -x509 -nodes -days 365 -newkey rsa:2048 -keyout https.key -out https.crt -subj "/CN=localhost"
```
