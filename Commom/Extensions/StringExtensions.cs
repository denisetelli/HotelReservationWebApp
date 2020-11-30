using System;

namespace Commom.Extensions
{
    public static class StringExtensions
    {
        public static string FormatCnpj(this string cnpj)
        {
            if (cnpj != null)
                return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            else
                return null;
        }

        public static string FormatCpf(this string cpf)
        {
            if (cpf != null)
                return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            else
                return null;
        }

        public static string FormatTelephone(this string phone)
        {
            if (phone != null)
                return Convert.ToUInt64(phone).ToString(@"\(00\)00000\-0000");
            else
                return null;
        }
    }
}
