using Commom.Providers;
using System;
using System.Linq;

namespace Business.Validators
{
    public class CpfValidator : IDocValidator
    {
        public bool ValidateDoc(IDocumentProvider cpfProvider)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cpfProvider.Cpf) && cpfProvider.Cpf.Length == 11 && cpfProvider.Cpf.All(char.IsDigit))
                {
                    int position = 0;
                    int digitsSum = 0;
                    for (int i = 10; i >= 2; i--)
                    {
                        digitsSum += int.Parse(cpfProvider.Cpf[position].ToString()) * i;
                        position++;
                    }
                    int firstCheckDigit = CalculateCheckDigit(digitsSum);

                    position = 0;
                    digitsSum = 0;
                    for (int i = 11; i >= 2; i--)
                    {
                        digitsSum += int.Parse(cpfProvider.Cpf[position].ToString()) * i;
                        position++;
                    }
                    int secondCheckDigit = CalculateCheckDigit(digitsSum);

                    if (firstCheckDigit == int.Parse(cpfProvider.Cpf[9].ToString())
                        && secondCheckDigit == int.Parse(cpfProvider.Cpf[10].ToString()))
                        return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public static int CalculateCheckDigit(int sum)
        {
            int checkDigit = 0;
            int rest = sum % 11;
            if (rest >= 2)
            {
                checkDigit = (11 - rest);
            }
            return checkDigit;
        }
    }
}
