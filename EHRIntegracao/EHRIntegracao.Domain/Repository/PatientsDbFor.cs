﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Query;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Repository
{
    public class PatientsDbFor
    {
        public virtual void inserirPacientes(IList<IPatientDTO> patients)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile("PatientsHospital"))
            {
                db.Store(patients);
            }
        }

        public virtual IList<IPatientDTO> Todos(IPatientDTO patient, DbEnum dbEnum)
        {
            IList<IPatientDTO> patients = new List<IPatientDTO>();
            using (IObjectServer server = Db4oClientServer.OpenServer("E://Projetos//EHR//PatientsHospital", 0))
            {
                using (IObjectContainer db = server.OpenClient())
                {
                    var iobject = db.Query<IPatientDTO>(p =>  p.Name.Contains(patient.Name) && p.Hospital == dbEnum);
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
