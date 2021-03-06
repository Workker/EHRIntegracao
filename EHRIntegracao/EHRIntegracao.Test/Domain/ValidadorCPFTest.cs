﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using NUnit.Framework;

namespace EHRIntegracao.Test.Domain
{
    [TestFixture]
    public class ValidadorCPFTest
    {
        [Test]
        public void verificar_cpf_com_sucesso() 
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsTrue(verificador.isCPF("14041907756"));
        }

        [Test]
        public void verificar_cpf_com_sucesso_com_pontos()
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsTrue(verificador.isCPF("140.419.077.56"));
        }

        [Test]
        public void verificar_cpf_sem_sucesso()
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsFalse(verificador.isCPF("10041907755"));
        }

        [Test]
        public void verificar_cpf_vazio_sem_sucesso()
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsFalse(verificador.isCPF(""));
        }

        [Test]
        public void verificar_cpf_nulo_sem_sucesso()
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsFalse(verificador.isCPF(null));
        }

        [Test]
        public void verificar_cpf_cheio_de_ponto_e_traco_nulo_sem_sucesso()
        {
            ValidateCPF verificador = new ValidateCPF();

            Assert.IsFalse(verificador.isCPF("..-"));
        }
    }
}
