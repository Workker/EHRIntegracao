using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Factorys
{
    public enum DbEnum : short
    {
        QuintaDor = 1,
        CopaDor = 2,
        sumario,
        QuintaDorWorkker

    }

    public class FacotoryAppValues
    {
        public static string GetValue(DbEnum key)
        {

            switch (key)
            {
                case DbEnum.QuintaDor:
                    return "QuintaDor";
                case DbEnum.CopaDor:
                    return "CopaDor";
                case DbEnum.sumario:
                    return "Sumario";
                case DbEnum.QuintaDorWorkker:
                    return "QuintaDorWorkker";
                default:
                    throw new Exception("Nenhuma chave corresponde ao valor informado");
            }
        }

    }
}
