namespace DotNetVerticalSliceTemplate.BuildingBlocks.CrossCuttingConcerns.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
        : base()
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }
}