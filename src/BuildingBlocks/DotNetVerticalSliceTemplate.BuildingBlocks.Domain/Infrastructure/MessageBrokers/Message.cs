using System.Text;
using System.Text.Json;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public class Message<T>
{
    public required MetaData MetaData { get; set; }

    public required T Data { get; set; }

    public string SerializeObject()
    {
        return JsonSerializer.Serialize(this);
    }

    public byte[] GetBytes()
    {
        return Encoding.UTF8.GetBytes(SerializeObject());
    }
}