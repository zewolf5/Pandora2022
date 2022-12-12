using Newtonsoft.Json;

namespace Pandora.Access.Access.Http;

public class JsonNewtonSerializer : ISerializer
{
    private readonly JsonSerializerSettings _serializerSettings;

    public JsonNewtonSerializer(JsonSerializerSettings settings)
    {
        _serializerSettings = settings;
    }

    public IEnumerable<T> DeserializeObject<T>(TextReader stream) where T : class
    {
        using (var reader = new JsonTextReader(stream))
        {
            var serializer = new JsonSerializer();
            if (!reader.Read() || reader.TokenType != JsonToken.StartArray)
                throw new Exception("Expected start of array in the deserialized json string");

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndArray) break;
                var item = serializer.Deserialize<T>(reader);
                yield return item;
            }
        }
    }

    public async Task<T> DeserializeObject<T>(string objectAsString) where T : class
    {
        return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(objectAsString));
    }

    public async Task<string> Serialize(object objToSerialize)
    {
        return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(objToSerialize, _serializerSettings));
    }
}