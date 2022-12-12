using Pandora.Access.Access.Http;
using Pandora.Common.Dto;
using Pandora.Common.Interface;
using System.Runtime.Intrinsics.X86;
using Pandora.Common;

namespace Pandora.Access.Access;

public class PandoraService : IPandoraAccess
{
    private readonly IHttpRestClient _httpClient;
    private readonly string _url;

    public PandoraService(IHttpRestClient client)
    {
        _httpClient = client;
        _url = "https://hackaton2022.azurewebsites.net/gov";
    }

    public RegistrationResponse RegisterIndividual(Registration person)
    {
        var initialDataUrl = $"{_url}/api/population/RegisterIndividual";
        return _httpClient.Post<Registration, RegistrationResponse>(initialDataUrl, person).Result;

    }

    public object CreateAccount(PersonData person)
    {
        throw new NotImplementedException();
    }

    public void NewJob(PersonData person)
    {
        throw new NotImplementedException();
    }

    public void QuitJob(PersonData person)
    {
        throw new NotImplementedException();
    }

    public void MarkPensionist(PersonData person)
    {
        throw new NotImplementedException();
    }

    public void BuyProduct(PersonData person, string productProduct, string productDescription, float productPrice)
    {
        throw new NotImplementedException();
    }

    public bool WithdrawMoney(PersonData person, float amount1)
    {
        throw new NotImplementedException(); //return ok
    }

    public void DepositMoney(PersonData person, float amount2)
    {
        throw new NotImplementedException();
    }

    public DateTime GetCurrentDate()
    {
        throw new NotImplementedException();
    }

    public float GetSalary(PersonData person)
    {
        return 0;
    }
}