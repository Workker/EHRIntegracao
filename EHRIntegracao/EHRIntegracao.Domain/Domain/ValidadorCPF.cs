using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EHRIntegracao.Domain.Domain
{
    //TODO: Pegar o melhor codigo do mundo
    public class ValidateCPF
    {
        public virtual bool isCPF(string cpf)
        {
            if (VerificarCampoVazio(cpf))
                return false;

            int[] d = new int[11];
            int[] v = new int[2];
            int j, i, soma;
            string SoNumero;

            SoNumero = Regex.Replace(cpf, "[^0-9]", string.Empty);

            if (NumerosIguais(SoNumero))
                return false;

            if (VerificarLength(SoNumero))
                return false;

            for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
            for (i = 0; i <= 1; i++)
            {
                soma = 0;
                for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                v[i] = (soma * 10) % 11;
                if (v[i] == 10) v[i] = 0;
            }
            return (v[0] == d[9] & v[1] == d[10]);
        }

        private bool VerificarLength(string cpf)
        {
            return cpf.Length != 11;
        }

        private bool NumerosIguais(string SoNumero)
        {
            if (string.IsNullOrEmpty(SoNumero))
                return true;

            return (new string(SoNumero[0], SoNumero.Length) == SoNumero);
        }

        private bool VerificarCampoVazio(string cpf)
        {
            return string.IsNullOrEmpty(cpf);
        }
    }
}
