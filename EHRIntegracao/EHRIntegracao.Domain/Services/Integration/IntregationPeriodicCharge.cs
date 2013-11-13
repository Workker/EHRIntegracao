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
