using Pandora.Common.Dto;

namespace Pandora.Common.Interface;

public interface IPandoraAccess
{
    RegistrationResponse RegisterIndividual(Registration person);
}