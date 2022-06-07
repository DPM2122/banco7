using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DMPBamco;
using System.Collections.Generic;

namespace DMPBancoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaValoresCorrectos_ResultadosEsperados()
        {
            EstadisticasNotas estadisticas = new EstadisticasNotas();
            List<int> listaNotas = new List<int>();

            listaNotas.Add(0);
            listaNotas.Add(5);
            listaNotas.Add(9);
            listaNotas.Add(3);
            listaNotas.Add(7);
            listaNotas.Add(4);
            listaNotas.Add(8);

            double mediaEsperada = 5.143;
            int suspensosEsperados = 3;
            int aprobadosEsperados = 1;
            int notablesEsperados = 2;
            int sobresalientesEsperados = 1;        
            estadisticas.CalculoEstadisticas(listaNotas);
     
            Assert.AreEqual(suspensosEsperados, estadisticas.NumeroSuspensos, "El numero de suspensos no coincide");
            Assert.AreEqual(aprobadosEsperados, estadisticas.NumeroAprobados, "El numero de Aprobados no coincide");
            Assert.AreEqual(notablesEsperados, estadisticas.NumeroNotables, "El numero de Notables no coincide");
            Assert.AreEqual(sobresalientesEsperados, estadisticas.NumeroSobresalientes, "El numero de Sobresalientes no coincide");
            Assert.AreEqual(mediaEsperada, estadisticas.Media, 0.001,  "La media no coincide");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "La lista no puede estar vacia")]
        public void PruebaListaVacia_ExcepcionEsperada()
        {
            EstadisticasNotas estadisticas = new EstadisticasNotas();
            List<int> listaNotas = new List<int>();
           
            estadisticas.CalculoEstadisticas(listaNotas);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Notas fuera de los rangos establecidos")]
        public void PruebaNotasIncorrectas_ExcepcionEsperada()
        {
            EstadisticasNotas estadisticas = new EstadisticasNotas();
            List<int> listaNotas = new List<int>();
            listaNotas.Add(0);
            listaNotas.Add(5);
            listaNotas.Add(-9);
            listaNotas.Add(3);
            listaNotas.Add(7);
            listaNotas.Add(4);
            listaNotas.Add(8);     
            estadisticas.CalculoEstadisticas(listaNotas);
        }




        //No necesaria. Para probar try & catch de la practica


        [TestMethod]
        public void PruebaNotasIncorrectas_TryCatch()
        {
            EstadisticasNotas estadisticas = new EstadisticasNotas();
            List<int> listaNotas = new List<int>();
            listaNotas.Add(0);
            listaNotas.Add(5);
            listaNotas.Add(-9);
            listaNotas.Add(3);
            listaNotas.Add(7);
            listaNotas.Add(4);
            listaNotas.Add(8);

           
            try
            {
                estadisticas.CalculoEstadisticas(listaNotas);
            }

            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Notas Fuera de rango valido");
                return;
            }
            Assert.Fail("Deberia haber fallado");

        }

    }
}
