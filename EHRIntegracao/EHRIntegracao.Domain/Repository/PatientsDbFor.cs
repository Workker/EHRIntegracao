using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace EHRIntegracao.Domain.Repository
{
    public class PatientsDbFor
    {
        public virtual void inserirPacientes(IList<IPatient> patients)
        {
            IList<IPatient> patientsLote1 = new List<IPatient>();
            IList<IPatient> patientsLote2 = new List<IPatient>();

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

        public virtual IList<IPatient> Todos(IPatient patient, Hospital hospital)
        {
            IList<IPatient> patients = new List<IPatient>();
            using (IObjectServer server = Db4oClientServer.OpenServer("E://Projetos//EHR//PatientsHospital", 0))
            {
                using (IObjectContainer db = server.OpenClient())
                {
                    var iobject = db.Query<IPatient>(p => p.Name.Contains(patient.Name) && p.Hospital == hospital);
                    patients = iobject.Cast<IPatient>().ToList();
                }
            }
            return patients;
        }

        public virtual IList<IPatient> Todos()
        {
            IList<IPatient> patients = new List<IPatient>();
            using (IObjectContainer db = Db4oEmbedded.OpenFile("PatientsHospital"))
            {
                var Iobject = db.QueryByExample(typeof(IPatient));
                patients = Iobject.Cast<IPatient>().ToList();
            }

            return patients;
        }
    }
}
