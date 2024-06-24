using EFCoreTypeHierarchyExample.Common.Data;
using EFCoreTypeHierarchyExample.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var context = new EFCoreTypeHierarchyExampleContext();
        var allVehicles = await context.Set<Vehicle>().ToListAsync();
        Console.WriteLine($"{allVehicles.Count} vehicles");
        
        foreach(var vehicle in allVehicles)
        {
            Console.WriteLine($"Vehicle \"{vehicle.Name}\" is a {vehicle.Type} (VIN {vehicle.VehicleIdentificationNumber})");
        }

        return 0;
    }
}