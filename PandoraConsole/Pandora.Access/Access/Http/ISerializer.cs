namespace Pandora.Access.Access.Http;

public interface ISerializer
{
    IEnumerable<T> DeserializeObject<T>(TextReader objectAsString) where T : class;
    Task<T> DeserializeObject<T>(string objectAsString) where T : class;
    Task<string> Serialize(object objToSerialize);
}