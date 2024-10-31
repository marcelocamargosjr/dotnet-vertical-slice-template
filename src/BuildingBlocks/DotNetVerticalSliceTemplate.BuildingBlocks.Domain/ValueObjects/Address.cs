namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.ValueObjects;

public record Address
{
    public string Street { get; }

    public string City { get; }

    public string ZipCode { get; }

    public Address(string street, string city, string zipCode)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
    }
}