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
