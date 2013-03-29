using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Console
{
    class Program
    {
        static void Main(string[] args)
        {
           // SavePatientsCacheService service = new SavePatientsCacheService();

            //Esse serviço eu insiro no memcache com a chave quintaDOrWorkker
            //service.Save(Domain.Factorys.DbEnum.QuintaDorWorkker);

            GetPatientsService serviceGet = new GetPatientsService();

            //Aqui eu recupero com a chave quintaDOrWorkker
            var result = serviceGet.GetPatientsRedis(Domain.Factorys.DbEnum.QuintaDorWorkker, new PatientDTO { Name = "ANA" });

            //Mas como vc viu, nao deu certo ;/
            System.Console.ReadLine();
        }
    }
}
