# EFCoreTypeHierarchyExample
This is a minimal example demonstrating the problem discussed in issue
[#33972](https://github.com/dotnet/efcore/issues/33972) in the
[Entity Framework Core](https://github.com/dotnet/efcore) repository.

## Steps to reproduce the issue
* Either create a migration using the dotnet tool in the `EFCoreTypeHierarchyExample.Common` folder:
    ```
    dotnet ef migrations add Init
    ```
* Or run the console application in the `EFCoreTypeHierarchyExample.Console` folder:
    ```
    dotnet run
    ```
