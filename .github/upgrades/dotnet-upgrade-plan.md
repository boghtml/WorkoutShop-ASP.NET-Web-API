# .NET 8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade WorkoutShop.Domain\WorkoutShop.Domain.csproj
4. Upgrade WorkoutShop.Application\WorkoutShop.Application.csproj
5. Upgrade WorkoutShop.Infrastructure\WorkoutShop.Infrastructure.csproj
6. Upgrade WorkoutShopAPI\WorkoutShopAPI.csproj

## Settings

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                | Current Version | New Version | Description                                   |
|:--------------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.AspNetCore.Authentication.JwtBearer |     7.0.5       |  8.0.22     | Recommended upgrade for .NET 8 compatibility. |
| Microsoft.AspNetCore.Identity.EntityFrameworkCore | 7.0.0       |  8.0.22     | Security and compatibility update for Identity EF Core. |
| Microsoft.AspNetCore.Identity.UI            |     7.0.0       |  8.0.22     | Security and compatibility update for Identity UI. |
| Microsoft.AspNetCore.OpenApi                 |     7.0.4       |  8.0.22     | Upgrade for OpenAPI/Swashbuckle compatibility with .NET 8. |
| Microsoft.EntityFrameworkCore.Tools         |     7.0.5       |  8.0.22     | Tools package update for EF Core 8 support.   |


### Project upgrade details

#### WorkoutShop.Domain\WorkoutShop.Domain.csproj

Project properties changes:
  - Target framework should be changed from `net7.0` to `net8.0`

NuGet packages changes:
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` should be updated from `7.0.0` to `8.0.22`.
  - `Microsoft.EntityFrameworkCore.Tools` should be updated from `7.0.5` to `8.0.22`.

Other changes:
  - Review code for any API breaking changes when moving to .NET 8 and EF Core 8.

#### WorkoutShop.Application\WorkoutShop.Application.csproj

Project properties changes:
  - Target framework should be changed from `net7.0` to `net8.0`

NuGet packages changes:
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` should be updated from `7.0.0` to `8.0.22`.
  - `Microsoft.EntityFrameworkCore.Tools` should be updated from `7.0.5` to `8.0.22`.

Other changes:
  - Review any API usages that may be affected by Identity / EF Core updates.

#### WorkoutShop.Infrastructure\WorkoutShop.Infrastructure.csproj

Project properties changes:
  - Target framework should be changed from `net7.0` to `net8.0`

NuGet packages changes:
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` should be updated from `7.0.0` to `8.0.22`.
  - `Microsoft.EntityFrameworkCore.Tools` should be updated from `7.0.5` to `8.0.22`.

Other changes:
  - Validate EF Core provider compatibility (Npgsql) for EF Core 8.

#### WorkoutShopAPI\WorkoutShopAPI.csproj

Project properties changes:
  - Target framework should be changed from `net7.0` to `net8.0`

NuGet packages changes:
  - `Microsoft.AspNetCore.Authentication.JwtBearer` should be updated from `7.0.5` to `8.0.22`.
  - `Microsoft.AspNetCore.Identity.EntityFrameworkCore` should be updated from `7.0.0` to `8.0.22`.
  - `Microsoft.AspNetCore.Identity.UI` should be updated from `7.0.0` to `8.0.22`.
  - `Microsoft.AspNetCore.OpenApi` should be updated from `7.0.4` to `8.0.22`.
  - `Microsoft.EntityFrameworkCore.Tools` should be updated from `7.0.5` to `8.0.22`.

Other changes:
  - Remove duplicate `AddControllers()` call in `Program.cs`.
  - Fix CORS policy: remove `AllowAnyOrigin()` when using `WithOrigins(...)`.
  - Verify JWT settings and `RoleClaimType` after package upgrades.
  - Ensure Npgsql provider is compatible with EF Core 8 and update Npgsql package if required.
