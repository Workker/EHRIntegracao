﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Repository
{
    public interface IPatientRepository
    {
        IList<T> GetAll<T>();
        IList<T> GetPatientsBy<T>(IPatientDTO patientDTO);
        void SalvarLista<T>(IList<T> roots);
    }
}
