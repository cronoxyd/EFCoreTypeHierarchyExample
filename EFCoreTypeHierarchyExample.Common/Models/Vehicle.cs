namespace EFCoreTypeHierarchyExample.Common.Models
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public VehicleType? Type { get; set; }
        public string VehicleIdentificationNumber { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
    }
}