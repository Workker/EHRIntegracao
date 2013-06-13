using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.InitialCharge;

namespace EHRIntegracao.Domain.Services.Integration
{
    public class IntregationPeriodicCharge
    {
        public void Do()
        {
            var service = new InitialChargeTreatmentByHospitalService();
            service.DoSearchPeriodic();

            var periodicChargeByHospital = new PeriodicChargeByHospitalService();
            periodicChargeByHospital.DoSearch();
        }
    }
}
