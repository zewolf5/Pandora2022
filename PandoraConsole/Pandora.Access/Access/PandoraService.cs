using Pandora.Access.Access.Http;
using Pandora.Common.Dto;
using Pandora.Common.Interface;

namespace Pandora.Access.Access;

public class PandoraService : IPandoraAccess
{
    private readonly IHttpRestClient _httpClient;
    private readonly string _url;

    public PandoraService(IHttpRestClient client)
    {
        _httpClient = client;
        _url = "";
    }

    public void RegisterIndividual(Registration person)
    {
        
    }
}