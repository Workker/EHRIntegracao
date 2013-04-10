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
        [ProtoEnum(Name = "BarraDor", Value = 1)]
        BarraDor = 1,
        [ProtoEnum(Name = "Sumario", Value = 2)]
        sumario,
        [ProtoEnum(Name = "QuintaDor", Value = 3)]
        QuintaDor,
        [ProtoEnum(Name = "QuintaDor", Value = 4)]
        QuintaDorProd

    }

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
                case DbEnum.QuintaDorProd:
                    return "QuintaDorProd";
                default:
                    throw new Exception("Nenhuma chave corresponde ao valor informado");
            }
        }

    }
}
