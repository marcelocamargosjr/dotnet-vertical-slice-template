namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }

    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}