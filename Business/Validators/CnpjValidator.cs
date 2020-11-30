using Commom.Providers;
using System;
using System.Linq;

namespace Business.Validators
{
    public class CnpjValidator : IDocValidator
    {

        public bool ValidateDoc(IDocumentProvider cnpjProvider)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cnpjProvider.Cnpj) && cnpjProvider.Cnpj.Length == 14 && cnpjProvider.Cnpj.All(char.IsDigit))
                {
                    int position = 0;
                    int digitsSum = 0;
                    for (int i = 5; i >= 2; i--)
                    {
                        digitsSum += int.Parse(cnpjProvider.Cnpj[position].ToString()) * i;
                        position++;
                        if (position == 4)
                        {
                            for (int j = 9; j >= 2; j--)
                            {
                                digitsSum += int.Parse(cnpjProvider.Cnpj[position].ToString()) * j;
                                position++;
                            }
                        }
                    }
                    int firstCheckDigit = CalculateCheckDigit(digitsSum);

                    position = 0;
                    digitsSum = 0;
                    for (int i = 6; i >= 2; i--)
                    {
                        digitsSum += int.Parse(cnpjProvider.Cnpj[position].ToString()) * i;
                        position++;
                        if (position == 5)
                        {
                            for (int j = 9; j >= 2; j--)
                            {
                                digitsSum += int.Parse(cnpjProvider.Cnpj[position].ToString()) * j;
                                position++;
                            }
                        }
                    }
                    int secondCheckDigit = CalculateCheckDigit(digitsSum);

                    if (firstCheckDigit == int.Parse(cnpjProvider.Cnpj[12].ToString())
                        && secondCheckDigit == int.Parse(cnpjProvider.Cnpj[13].ToString()))
                        return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public int CalculateCheckDigit(int sum)
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

