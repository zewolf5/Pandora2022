using Pandora.Access.Access.Http;
using Pandora.Common.Dto;
using Pandora.Common.Interface;
using System.Runtime.Intrinsics.X86;
using Pandora.Common;
using IO.Swagger.Api;

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
        string firstname = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[0];
        string lastName = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[1];

        var account2 = new TheAbcBankApi("https://hackaton2022.azurewebsites.net");
        var ret = account2.TheAbcBankApiVisitPost(new IO.Swagger.Model.ApiVisitBody { Passport = person.PassportInfo.passport });
        account2.Configuration.AddDefaultHeader("x-access-token", ret.AccessToken);
        var ret2 = account2.TheAbcBankApiCustomerOpenAccountPost(new IO.Swagger.Model.CustomerOpenAccountBody(firstname, lastName, person.OrignalData.Identifikator));
        return ret2;
    }

    public void NewJob(PersonData person)
    {
        string firstname = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[0];
        string lastName = person.OrignalData.Visningnavn.Split(" ", StringSplitOptions.None)[1];
        var date = DateTime.Parse(person.OrignalData.Foedselsdato);

        var client = new EmploymentApi("https://hackaton2022.azurewebsites.net");
        client.GovApiEmployeeAddPost(new IO.Swagger.Model.EmployeeAddBody(date, firstname, lastName, person.OrignalData.Identifikator, person.PassportInfo.passport));

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
        var client = new SimulationApi("https://hackaton2022.azurewebsites.net");
        var curTime = client.CurrentTimeGetWithHttpInfo();
        return DateTime.Now;
    }

    public float GetSalary(PersonData person)
    {
        return 0;
    }
}