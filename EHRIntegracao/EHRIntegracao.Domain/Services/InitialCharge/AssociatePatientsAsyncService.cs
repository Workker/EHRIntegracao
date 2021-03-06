﻿using EHR.CoreShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class AssociateTreatmentsAsyncService
    {
        public int fatia = 200;
        public int totalDePacientesExistentes;
        public int TotalDePacientesEmProcessamento = 0;
        public int totalDePacientesProcessados = 0;
        public int totalDeThreadsEmAndamento = 0;
        public const int totaldeThreadsPossiveis = 10;
        public delegate void AssociateTreatments(List<IPatient> pacientes);
        public List<string> resultadoTotal;
        public static AutoResetEvent gerenciadorDeThreads = new AutoResetEvent(false);
        public int totalTerminadas = 0;
        public List<IPatient> patients;

        public AssociateTreatmentsAsyncService(List<IPatient> patients)
        {
            this.patients = patients;
        }

        public void Executar()
        {
            Console.WriteLine("Inicio do Processo");

            var relogio = new Stopwatch();

            relogio.Start();

            var service = new AssociatePatientsToTreatmentsService();

            var servicoObterTratamentos = new AssociateTreatments(service.Associate);

            totalDePacientesProcessados = 0;

            Processar(servicoObterTratamentos);

            Finalizar(relogio);
        }

        private void Processar(AssociateTreatments servicoObterTratamentos)
        {
            totalDePacientesExistentes = patients.Count;

            while (totalDePacientesProcessados < totalDePacientesExistentes)
            {
                SegurarProcessador();

                // TODO: ObterPacientes -- Paginando
                var pacientes = patients.Skip(totalDePacientesProcessados).Take(fatia).ToList();

                servicoObterTratamentos.BeginInvoke(pacientes, MetodoQueSeraExecutadoAposOMetodoDoDelegate, servicoObterTratamentos);
                FatiarPacientes();
            }
        }

        private void FatiarPacientes()
        {
            int totalDePacientes = totalDePacientesExistentes - totalDePacientesProcessados;

            if (totalDePacientes < fatia)
                totalDePacientesProcessados += totalDePacientes;
            else
                totalDePacientesProcessados += fatia;

            Console.WriteLine("Processados" + totalDePacientesProcessados);
        }

        public void MetodoQueSeraExecutadoAposOMetodoDoDelegate(IAsyncResult iar)
        {
            if (iar.IsCompleted)
            {
                totalDeThreadsEmAndamento -= 1;
            }

            var func = (AssociateTreatments)iar.AsyncState;
            func.EndInvoke(iar);

            if (totalDePacientesProcessados >= totalDePacientesExistentes)
            {
                totalTerminadas = totalDePacientesProcessados;
                gerenciadorDeThreads.Set();
            }
        }

        private void Finalizar(Stopwatch relogio)
        {
            if (patients.Count > 0)
                gerenciadorDeThreads.WaitOne();

            relogio.Stop();

            Console.WriteLine(relogio.Elapsed.TotalSeconds);
        }

        private void SegurarProcessador()
        {
            totalDeThreadsEmAndamento += 1;

            while (totalDeThreadsEmAndamento == totaldeThreadsPossiveis)
            {
                //Mantém o processador 
            }
        }
    }
}
