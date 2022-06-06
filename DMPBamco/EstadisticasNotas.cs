using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMPBamco
{
    /// <summary>
    /// La clase calcula las estadisticas de un conjunto de notas
    /// </summary>
    public class EstadisticasNotas
    {/// <summary>
     /// 
     /// </summary>
        private int mnumeroSuspensos;
        /// <summary>
        /// 
        /// </summary>
        private int mnumeroAprobados;
        /// <summary>
        /// 
        /// </summary>
        private int mnumeroNotables;
        /// <summary>
        /// 
        /// </summary>
        private int mnumeroSobresalientes;
        /// <summary>
        /// 
        /// </summary>
        private double nmedia;
        /// <summary>
        /// 
        /// </summary>
        private const int valorSuspenso = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int valorAprobado = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int valorNotable = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int valorSobresaliente = 0;
        /// <summary>
        /// 
        /// </summary>
        private const int valorSobresalienteExtremo = 0;

        /// <summary>
        /// 
        /// </summary>
        public int NumeroSuspensos { get => mnumeroSuspensos; set => mnumeroSuspensos = value; }
        /// <summary>
        /// 
        /// </summary>
        public int NumeroAprobados { get => mnumeroAprobados; set => mnumeroAprobados = value; }
        /// <summary>
        /// 
        /// </summary>
        public int NumeroNotables { get => mnumeroNotables; set => mnumeroNotables = value; }
        /// <summary>
        /// 
        /// </summary>
        public int NumeroSobresalientes { get => mnumeroSobresalientes; set => mnumeroSobresalientes = value; }
        /// <summary>
        /// 
        /// </summary>
        public double Media { get => nmedia; set => nmedia = value; }

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public EstadisticasNotas()
        {
            NumeroSuspensos = 0;
            NumeroAprobados = 0;
            NumeroNotables = 0;
            NumeroSobresalientes = 0;
            Media = 0.0;
        }

        /// <summary>
        /// Construcctor a partir de un array. Calcula las notas a partir de una lista
        /// </summary>
        /// <param name="listaNotas">Lista con las notas de los alumnos</param>
        public EstadisticasNotas(List<int> listaNotas)
        {
            Estadisticas(listaNotas);
        }


        /// <summary>
        /// Metodo que calcula las estadisticas 
        /// </summary>
        /// <param name="listaNotas">Lista con las notas de los alumnos</param>
        private void Estadisticas(List<int> listaNotas)
        {

            Media = 0.0;

            for (int i = 0; i < listaNotas.Count; i++)
            {
                if (listaNotas[i] < 5) NumeroSuspensos++;              // Por debajo de 5 suspenso
                else if (listaNotas[i] >= valorAprobado && listaNotas[i] < valorNotable) NumeroAprobados++;// Nota para aprobar: 5
                else if (listaNotas[i] >= valorNotable && listaNotas[i] < valorSobresaliente) NumeroNotables++;// Nota para notable: 7
                else if (listaNotas[i] >= valorSobresaliente && listaNotas[i] <= valorSobresalienteExtremo) NumeroSobresalientes++;         // Nota para sobresaliente: 9

                Media = Media + listaNotas[i];
            }

            Media = Media / listaNotas.Count;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaNotas">Lista con las notas de los alumnos</param>
        /// <returns>Media de las notas</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Cuando notas fuera de rango</exception>
        /// <exception cref="System.Exception">Cuando la lista esta vacia</exception>
        public double CalculoEstadisticas(List<int> listaNotas)
        {
            if (listaNotas.Count <= 0)
            {
                throw new Exception("Lista Vacia");
            }

            for (int i = 0; i < listaNotas.Count; i++)
                if (listaNotas[i] < 0 || listaNotas[i] > 10)
                {
                    throw new ArgumentOutOfRangeException("Contador i", i, "Notas Fuera de rango valido");
                }

            Estadisticas(listaNotas);

            return Media;
        }
    }
}
