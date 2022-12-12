using Pandora.Common.Dto;

namespace Pandora.Common.Interface;

public interface IPandoraAccess
{
    RegistrationResponse RegisterIndividual(Registration person);
    object CreateAccount(PersonData person);
    void NewJob(PersonData person);
    void QuitJob(PersonData person);
    void MarkPensionist(PersonData person);
    void BuyProduct(PersonData person, string productProduct, string productDescription, float productPrice);
    bool WithdrawMoney(PersonData person, float amount1);
    void DepositMoney(PersonData person, float amount2);
    DateTime GetCurrentDate();
}