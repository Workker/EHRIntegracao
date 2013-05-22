using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Query;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;


namespace EHRIntegracao.Domain.Repository
{
    public class PatientsDbFor
    {
        public virtual void inserirPacientes(IList<IPatientDTO> patients)
        {
            IList<IPatientDTO> patientsLote1 = new List<IPatientDTO>();
            IList<IPatientDTO> patientsLote2 = new List<IPatientDTO>();

            for (int i = 0; i < patients.Count / 2; i++)
            {
                patientsLote1.Add(patients[i]);
            }
            for (int i = (patients.Count / 2); i < (patients.Count); i++)
            {
                patientsLote2.Add(patients[i]);
            }

            using (IObjectContainer db = Db4oEmbedded.OpenFile("PatientsHospital"))
            {
                db.Store(patientsLote1);
            }

            using (IObjectContainer db = Db4oEmbedded.OpenFile("PatientsHospital"))
            {
                db.Store(patientsLote2);
            }
        }

        public virtual IList<IPatientDTO> Todos(IPatientDTO patient, DbEnum dbEnum)
        {
            IList<IPatientDTO> patients = new List<IPatientDTO>();
            using (IObjectServer server = Db4oClientServer.OpenServer("E://Projetos//EHR//PatientsHospital", 0))
            {
                using (IObjectContainer db = server.OpenClient())
                {
                    var iobject = db.Query<IPatientDTO>(p => p.Name.Contains(patient.Name) && p.Hospital == dbEnum);
                    patients = iobject.Cast<IPatientDTO>().ToList();
                }
            }
            return patients;
        }

        public virtual IList<IPatientDTO> Todos()
        {
            IList<IPatientDTO> patients = new List<IPatientDTO>();
            using (IObjectContainer db = Db4oEmbedded.OpenFile("PatientsHospital"))
            {
                var Iobject = db.QueryByExample(typeof(IPatientDTO));
                patients = Iobject.Cast<IPatientDTO>().ToList();
            }

            return patients;
        }
    }
}
