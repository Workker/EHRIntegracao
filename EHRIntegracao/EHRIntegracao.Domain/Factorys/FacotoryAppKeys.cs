using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace EHRIntegracao.Domain.Factorys
{
    [Serializable]
    [ProtoContract(SkipConstructor = true)]
    public enum DbEnum : short
    {
        [ProtoEnum(Name = "QuintaDor", Value = 1)]
        QuintaDor = 1,
        [ProtoEnum(Name = "CopaDor", Value = 2)]
        CopaDor = 2,
        [ProtoEnum(Name = "sumario", Value = 3)]
        sumario,
        [ProtoEnum(Name = "QuintaDorWorkker", Value = 4)]
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
