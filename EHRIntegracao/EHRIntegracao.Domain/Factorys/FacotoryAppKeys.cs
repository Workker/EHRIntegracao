using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using ProtoBuf;

namespace EHRIntegracao.Domain.Factorys
{
    public class FacotoryAppValues
    {
        public static string GetValue(DbEnum key)
        {

            switch (key)
            {
                case DbEnum.BarraDor:
                    return "BarraDor";
                case DbEnum.sumario:
                    return "Sumario";
                case DbEnum.QuintaDor:
                    return "QuintaDor";
                default:
                    throw new Exception("Nenhuma chave corresponde ao valor informado");
            }
        }

    }
}
