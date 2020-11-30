using Commom.Enums;
using System;

namespace Business.Validators
{
    public static class DocValidatorFactory
    {
        public static IDocValidator Create (ClientTypeEnum client)
        {
            switch (client)
            {
                case ClientTypeEnum.Person:
                    return new CpfValidator();
                case ClientTypeEnum.Organization:
                    return new CnpjValidator();
            }
            throw new Exception ("Falha ao cliar validador de documento.");
        }
    }
}
